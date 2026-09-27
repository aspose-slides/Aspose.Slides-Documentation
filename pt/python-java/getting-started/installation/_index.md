---
title: Instalação
type: docs
weight: 70
url: /pt/python-java/installation/
keywords:
- baixar Aspose.Slides
- instalar Aspose.Slides
- Instalação do Aspose.Slides
- Python
- Java
- JPype
- Windows
- macOS
- Linux
description: "Instale Aspose.Slides for Python via Java no Windows, Linux ou macOS, configure Java e JPype e verifique a configuração com um exemplo funcional."
---
Aspose.Slides for Python via Java funciona em Windows, Linux e macOS. Ele usa JPype para acessar a biblioteca Java a partir do Python. O Microsoft PowerPoint não é necessário.

## **Pré-requisitos**

Antes de instalar os pacotes Python, instale o Python e um JDK que atendam aos [Requisitos do Sistema](/slides/pt/python-java/system-requirements/). Essa página lista versões compatíveis, requisitos de arquitetura e quaisquer dependências necessárias para compilar o JPype a partir do código-fonte.

Defina `JAVA_HOME` para o diretório de instalação do JDK, não para o subdiretório `bin`, e adicione o diretório `bin` do JDK ao `PATH`. Abra um novo terminal após alterar as variáveis de ambiente.

## **Instalar a partir do PyPI**

Execute os comandos a seguir em um terminal, não no prompt interativo do Python. Crie um diretório de projeto e um ambiente virtual para manter os pacotes isolados de outros projetos.

### **Windows**

Com o interpretador Python escolhido disponível como `python` no `PATH`, execute os comandos a seguir no Prompt de Comando:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux e macOS**

Com a versão do Python escolhida disponível como `python3`, execute os comandos a seguir no Bash ou zsh:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

No Debian ou Ubuntu, se a criação do ambiente falhar porque `ensurepip` não está disponível, instale o pacote `python3-venv` com `sudo apt-get install python3-venv` e repita o comando de criação do ambiente. Uma versão do Python instalada separadamente pode precisar do pacote `venv` correspondente à sua versão.

### **Instalar os Pacotes**

Com o ambiente virtual ativo, instale JPype e Aspose.Slides:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

Usar `python -m pip` garante que os pacotes sejam instalados para o interpretador usado para executar sua aplicação.

Para atualizar uma instalação existente do Aspose.Slides, execute `python -m pip install --upgrade aspose-slides-java` no mesmo ambiente.

## **Instalar a partir de um Arquivo ZIP**

Você também pode usar a biblioteca a partir da [página de downloads do Aspose.Slides](https://releases.aspose.com/slides/pt/python-java/):

1. Instale o Python e o Java conforme descrito em [Pré-requisitos](#prerequisites).
2. Crie e ative um ambiente virtual usando as instruções acima.
3. Instale o JPype com `python -m pip install JPype1`.
4. Baixe e extraia o arquivo ZIP do Aspose.Slides for Python via Java.
5. Localize o diretório do pacote `asposeslides` extraído. Mantenha seu conteúdo, incluindo o diretório `lib` e o arquivo JAR, juntos.
6. Coloque o `example.py` da próxima seção ao lado do diretório `asposeslides` para que o Python possa importar o pacote. O arquivo já contém seu próprio `example.py` próximo ao `asposeslides`; substitua‑o pelo abaixo.

## **Verificar a Instalação**

Salve o código a seguir como `example.py`. Ele cria uma apresentação com uma caixa de texto e a salva como `out.pptx` no diretório de trabalho atual.

```python
import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Presentation, SaveFormat, ShapeType

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 500, 80)
        shape.getTextFrame().setText("Aspose.Slides is ready!")
        presentation.save("out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    jpype.shutdownJVM()
```

Com o ambiente virtual ativo, execute o exemplo a partir do diretório que contém `example.py`:

```sh
python example.py
```

A importação `asposeslides` registra a biblioteca Java empacotada antes de a JVM iniciar. Importe `asposeslides.api` após iniciar a JVM e libere os recursos da apresentação antes de encerrá‑la.

{{% alert color="info" title="Note" %}}
Sem uma licença, a saída inclui uma marca d'água de avaliação. Veja [Avaliar Aspose.Slides](/slides/pt/python-java/evaluate-aspose-slides/) para limitações da avaliação e informações sobre licença temporária.
{{% /alert %}}

## **Perguntas Frequentes**

**Por que o Python informa que a JVM não pode ser encontrada ou carregada?**

Verifique se `JAVA_HOME` aponta para um JDK compatível com sua instalação do Python e JPype, conforme descrito nos [Requisitos do Sistema](/slides/pt/python-java/system-requirements/). Consulte o [guia de solução de problemas da instalação do JPype](https://jpype.readthedocs.io/en/latest/install.html) para verificações adicionais.

**Por que o Python informa que `asposeslides` está ausente após a instalação?**

O pacote pode ter sido instalado para um interpretador Python diferente. Ative o ambiente virtual usado na instalação e execute `python -m pip show aspose-slides-java`. Para uma instalação via ZIP, certifique‑se de que o diretório `asposeslides` esteja ao lado do seu script ou, de outra forma, disponível no caminho de busca de módulos do Python.

**Posso executar o exemplo repetidamente em um notebook?**

O exemplo destina‑se a um processo Python independente. Antes de adaptá‑lo para execução repetida em notebook, consulte [Limitações e Diferenças de API](/slides/pt/python-java/limitations-and-api-differences/#import-the-library) para o ciclo de vida da JVM e orientações sobre notebooks.

**Por que o pip falha com `CERTIFICATE_VERIFY_FAILED`?**

Se sua rede usa um proxy de inspeção HTTPS, o pip deve confiar na autoridade certificadora desse proxy. Configure o bundle de CA confiável usando a opção `--cert` do pip ou a variável de ambiente `PIP_CERT`, seguindo as [instruções de certificado HTTPS do pip](https://pip.pypa.io/en/stable/topics/https-certificates/). A configuração necessária depende da sua rede e da versão do pip.