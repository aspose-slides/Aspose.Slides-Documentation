---
title: Instalação
type: docs
weight: 70
url: /pt/python-net/installation/
keywords:
- baixar Aspose.Slides
- instalar Aspose.Slides
- usar Aspose.Slides
- instalação do Aspose.Slides
- Windows
- macOS
- Python
description: "Aprenda a instalar rapidamente o Aspose.Slides para Python via .NET. Guia passo a passo, requisitos do sistema e exemplos de código — comece a trabalhar com apresentações PowerPoint hoje!"
---
## **Visão geral**

O pacote Aspose.Slides for Python via .NET vem com todas as bibliotecas .NET essenciais incluídas, o que significa que não há necessidade de instalar o .NET separadamente. Isso simplifica o processo de configuração e permite que os desenvolvedores comecem a trabalhar com apresentações imediatamente. No entanto, é importante observar que, dependendo do seu sistema operacional ou ambiente, pode ser necessário instalar algumas dependências específicas da plataforma exigidas pelo .NET. Além disso, certos requisitos de sistema devem ser atendidos para garantir total compatibilidade e funcionamento adequado do pacote.

## **Windows**

**Requisitos do sistema**

Verifique e confirme que as especificações da sua máquina atendem ou excedem os [requisitos do sistema](/slides/pt/python-net/system-requirements/).

### **Instalar Aspose.Slides**

`pip` é a maneira mais fácil de baixar e instalar [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) no Windows.

Para instalar o Aspose.Slides, execute o comando a seguir:

```sh
pip install aspose-slides
```

**Usar Aspose.Slides**

Teste a instalação do Aspose.Slides executando o código a seguir para criar uma apresentação PowerPoint:

```python
# Importe o módulo Aspose.Slides para Python via .NET.
import aspose.slides as slides

# Instancie a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **macOS**

**Requisitos do sistema**

Verifique e confirme que as especificações da sua máquina atendem ou excedem os [requisitos do sistema](/slides/pt/python-net/system-requirements/).

### **Pré-requisitos**

**Python com Bibliotecas Compartilhadas**

Existem várias maneiras de instalar o Python no macOS, mas recomendamos fortemente o uso da [ferramenta pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos).

Depois de instalar e configurar o **pyenv**, instale o Python com bibliotecas compartilhadas executando os seguintes comandos no aplicativo Terminal:

1. Instalar Python:

```sh
env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13
```

2. Defina como a versão global do Python:

```sh
pyenv global 3.9.13
```

3. Defina como a versão do Python específica do shell:

```sh
pyenv shell 3.9.13
```

4. Crie um link simbólico para a biblioteca libpython em um diretório de bibliotecas do sistema:

```sh
ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib
```

Observação: Python 3.5 ou superior é necessário. A versão 3.9.13 é usada aqui apenas como exemplo.

**Instalar a Biblioteca libgdiplus**

A biblioteca **libgdiplus** é uma implementação do Windows GDI+ para macOS e Linux que o .NET utiliza para funcionalidade gráfica nessas plataformas. Para instalar esta biblioteca no macOS, execute o comando a seguir:

```sh
brew install mono-libgdiplus
```

### **Instalar Aspose.Slides**

`pip` é a maneira mais fácil de baixar e instalar [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) no macOS.

Para instalar o Aspose.Slides, execute o comando a seguir:

```sh
pip install aspose-slides
```

**Usar Aspose.Slides**

Teste a instalação do Aspose.Slides executando o código a seguir para criar uma apresentação PowerPoint:

```python
# Importe o módulo Aspose.Slides para Python via .NET.
import aspose.slides as slides

# Instancie a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso instalar o Aspose.Slides em um ambiente virtual?**

Sim, você pode instalá-lo em qualquer ambiente virtual Python usando `pip`. Apenas certifique-se de que o ambiente tenha acesso às dependências nativas necessárias, dependendo do seu sistema operacional.

**Posso usar o Aspose.Slides em contêineres Docker?**

Sim, mas você precisa garantir que sua imagem Docker inclua as bibliotecas nativas necessárias (**libgdiplus**, pacotes de fontes, etc.) e a versão correta do Python.

**Existe uma versão gratuita ou limitação de avaliação?**

Sim, por padrão, o Aspose.Slides funciona em modo de avaliação, que adiciona marcas d'água e pode ter outras limitações. Para remover as restrições, você precisa aplicar uma [licença](/slides/pt/python-net/licensing/).