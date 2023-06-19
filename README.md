# Relatório Técnico
# Disciplica Algoritmos Avançados
# Engenharia de Software
# Prof. Paulo Manseira

# Aluno: Igor Tomasi

## Introdução

O problema do caixeiro viajante é um desafio clássico em otimização combinatória, que busca encontrar a rota mais curta para que um viajante visite todas as cidades em um conjunto, retornando à cidade de origem. Nesta resolução, exploramos duas heurísticas amplamente utilizadas: a busca tabu e o algoritmo genético, aplicadas às coordenadas de latitude e longitude fornecidas para um conjunto específico de cidades.

As cidades de Brasília, Rio de Janeiro, Belo Horizonte, São Paulo, Salvador, Porto Alegre, Fortaleza, Recife, Curitiba, Manaus, Joinville, Lages, Ouro Preto, Blumenau, Florianópolis, Acre e Fernando de Noronha foram consideradas como entrada de dados. Cada cidade é representada por suas coordenadas de latitude e longitude.

Utilizando a busca tabu, exploramos o espaço de solução, realizando movimentos entre as cidades e buscando uma rota que minimize a distância total percorrida. A busca tabu utiliza uma memória de curto prazo para evitar ciclos infinitos ou retornar a soluções previamente visitadas. Dessa forma, avaliamos o desempenho da busca tabu em termos de tempo de execução e qualidade da solução encontrada.

Além disso, utilizamos o algoritmo genético, uma abordagem baseada em conceitos da teoria da evolução, para resolver o problema. O algoritmo genético cria uma população inicial de rotas, que são combinadas e mutadas ao longo de várias gerações para encontrar soluções melhores. Avaliamos o desempenho do algoritmo genético em relação ao tempo de execução e qualidade da solução obtida.

## Motivação

O problema do caixeiro viajante desperta um grande interesse e desafia pesquisadores e profissionais da área de otimização há décadas. A motivação para resolver esse problema está intrinsecamente ligada à busca por soluções eficientes em diversas áreas práticas, como logística, roteirização, planejamento urbano, transporte e muitas outras.

Encontrar a rota mais curta para um caixeiro viajante visitar um conjunto de cidades tem implicações diretas na economia de recursos, tempo e custos. Uma solução eficiente para o problema pode levar a reduções significativas em gastos de combustível, tempo de entrega, emissões de carbono e melhoria na eficiência geral de processos logísticos e de transporte.

## Objetivos

Portanto, nosso objetivo é avaliar e comparar o desempenho dessas duas heurísticas, considerando métricas como tempo de execução e qualidade da solução encontrada. Buscamos obter soluções de boa qualidade para o problema do caixeiro viajante, levando em conta as restrições impostas pelo conjunto de cidades fornecido.

## Metodologia

Para resolver o problema do caixeiro viajante utilizando as heurísticas de busca tabu e algoritmo genético, adotaremos a seguinte metodologia:

1. **Definição das cidades e coordenadas**: Utilizaremos as cidades fornecidas como entrada de dados, juntamente com suas coordenadas de latitude e longitude. Essas informações serão utilizadas para calcular as distâncias entre as cidades e construir a matriz de distâncias.

2. **Implementação da busca tabu**: Faremos a implementação da busca tabu em C#, considerando as coordenadas de latitude e longitude. A busca tabu será responsável por explorar o espaço de solução, realizando movimentos entre as cidades e mantendo uma memória de curto prazo para evitar soluções repetidas. A busca tabu buscará minimizar a distância total percorrida.

3. **Avaliação da busca tabu**: Executaremos a busca tabu para encontrar uma solução aproximada para o problema do caixeiro viajante. Avaliaremos o desempenho da busca tabu em termos de tempo de execução e qualidade da solução encontrada. Mediremos a distância total percorrida pela rota encontrada e compararemos com soluções conhecidas, quando disponíveis.

4. **Implementação do algoritmo genético**: Realizaremos a implementação do algoritmo genético em C#, levando em consideração as coordenadas de latitude e longitude das cidades. O algoritmo genético criará uma população inicial de rotas, combinando e mutando soluções ao longo de várias gerações para encontrar rotas mais curtas e de melhor qualidade.

5. **Avaliação do algoritmo genético**: Executaremos o algoritmo genético para obter soluções aproximadas para o problema do caixeiro viajante. Avaliaremos o desempenho do algoritmo genético em relação ao tempo de execução e qualidade da solução obtida. Mediremos a distância total percorrida pela rota encontrada e compararemos com soluções conhecidas, quando disponíveis.

6. **Comparação e análise**: Compararemos os resultados obtidos pela busca tabu e pelo algoritmo genético. Analisaremos o desempenho de cada heurística em relação ao tempo de execução e qualidade da solução encontrada. Observaremos se as soluções encontradas são próximas da solução ótima conhecida, quando disponível.

## Experimentos

1. **Experimento 1 - Busca Tabu**:
   - Executaremos a busca tabu para o conjunto de cidades fornecido, utilizando um determinado número de iterações (100).
   - Mediremos o tempo de execução da busca tabu para encontrar a solução.

2. **Experimento 2 - Algoritmo Genético**:
   - Implementaremos o algoritmo genético para o conjunto de cidades fornecido, definindo os parâmetros como tamanho da população (Min 50; Max: 100), número de gerações e taxa de mutação.
   - Executaremos o algoritmo genético para obter uma solução aproximada.
   - Registraremos o tempo de execução necessário para encontrar a solução.
