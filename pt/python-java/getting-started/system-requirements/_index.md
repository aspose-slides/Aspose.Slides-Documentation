---
title: Requisitos do Sistema
type: docs
weight: 60
url: /pt/python-java/system-requirements/
keywords:
- requisitos do sistema
- Python
- Java
- JPype
- Windows
- Linux
- macOS
- Aspose.Slides
description: "Verifique os requisitos de sistema operacional, Python, Java e JPype para executar o Aspose.Slides for Python via Java no Windows, Linux e macOS."
---
## **Visão Geral**

Aspose.Slides for Python via Java cria, modifica, converte e renderiza apresentações sem a necessidade de Microsoft PowerPoint instalado. Ele usa JPype para acessar a biblioteca Java a partir do Python, portanto o ambiente deve suportar Python, Java e JPype juntos.

## **Sistemas Operacionais Suportados**

O [Aspose.Slides package](https://pypi.org/project/aspose-slides-java/) suporta as seguintes famílias de sistemas operacionais:

- Windows
- Linux
- macOS

Escolha uma versão do sistema operacional suportada pelas versões selecionadas de Python, Java e JPype. A disponibilidade apenas do Java não estabelece compatibilidade com o pacote Python e sua ponte.

## **Requisitos de Python, Java e JPype**

| Componente | Requisito |
| --- | --- |
| Python | O pacote Aspose.Slides declara suporte ao Python 3.7 até 3.14. A versão selecionada do JPype deve suportar a mesma versão do Python; por exemplo, [JPype1 1.7.1](https://pypi.org/project/jpype1/1.7.1/) requer Python 3.8 ou posterior. |
| Java | Instale um runtime Java ou JDK compatível com a versão selecionada do JPype. Os [requisitos do JPype](https://jpype.readthedocs.io/en/latest/userguide.html#prerequisites) atuais especificam Java 11 ou posterior. Java 8 não pode executar JPype1 1.7.1. |
| JPype | Instale o pacote JPype1 para o seu interpretador Python, sistema operacional e arquitetura de CPU. |
| Arquitetura de CPU | Python e a Máquina Virtual Java (JVM) devem usar arquiteturas correspondentes. Por exemplo, um interpretador Python de 64 bits requer uma JVM de 64 bits compatível. |

No Apple Silicon, Python e Java devem ambos usar ARM64 ou ambos usar x64. Uma JVM que funciona de forma independente ainda pode falhar ao ser carregada através do JPype se sua arquitetura for diferente da do Python.

Para um novo ambiente, Python 3.12, JDK 17 e JPype1 1.7.1 são um ponto de partida adequado. Essa combinação foi verificada com Aspose.Slides for Python via Java 26.6.0 no Windows. Outras combinações devem atender aos requisitos dos três componentes.

Para configuração do ambiente e um exemplo de verificação funcional, veja [Instalação](/slides/pt/python-java/installation/).

## **Dependências Adicionais**

Um wheel JPype pré-compilado compatível não requer um compilador C++. Se o JPype precisar ser compilado a partir do código-fonte, instale um compilador C++ compatível e os arquivos de desenvolvimento do Python exigidos pela sua plataforma. Consulte as [instruções de instalação do JPype](https://jpype.readthedocs.io/en/latest/install.html) para requisitos de compilação e solução de problemas.

## **FAQ**

**Preciso ter o Microsoft PowerPoint instalado?**

Não. Aspose.Slides processa apresentações independentemente do PowerPoint. Python, Java e JPype ainda são necessários.

**Posso usar Python 3.7 com qualquer versão do JPype?**

Não. Embora o pacote Aspose.Slides declare suporte ao Python 3.7, o JPype1 1.7.1 requer Python 3.8 ou posterior. Escolha versões cujos requisitos se sobreponham.

**Posso combinar Python de 32 bits com Java de 64 bits?**

Não. O JPype carrega a JVM no processo Python, portanto Python e Java devem ter arquiteturas correspondentes. O mesmo requisito se aplica a ARM64 e x64 no macOS.