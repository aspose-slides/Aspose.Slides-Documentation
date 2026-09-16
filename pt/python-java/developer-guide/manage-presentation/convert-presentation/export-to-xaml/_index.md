---
title: Exportar apresentações para XAML em Python via Java
linktitle: Apresentação para XAML
type: docs
weight: 30
url: /pt/python-java/export-to-xaml/
keywords:
- exportar PowerPoint
- exportar OpenDocument
- exportar apresentação
- converter PowerPoint
- converter OpenDocument
- converter apresentação
- PowerPoint para XAML
- OpenDocument para XAML
- apresentação para XAML
- PPT para XAML
- PPTX para XAML
- ODP para XAML
- salvar PPT como XAML
- salvar PPTX como XAML
- salvar ODP como XAML
- exportar PPT para XAML
- exportar PPTX para XAML
- exportar ODP para XAML
- Python
- Java
- Aspose.Slides
description: "Exporte apresentações PowerPoint e OpenDocument para XAML com Aspose.Slides para Python via Java. Use opções padrão ou inclua slides ocultos."
---
## **Visão geral**

Este artigo explica como exportar apresentações do PowerPoint para XAML usando Aspose.Slides for Python via Java. Inclui uma breve introdução ao XAML, mostra como salvar uma apresentação em XAML com as configurações padrão e demonstra como personalizar a exportação através do [XamlOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/xamloptions/), incluindo a exportação de slides ocultos. O artigo também responde a algumas perguntas comuns relacionadas a fontes de fallback, compatibilidade de pilhas XAML e comportamento de exportação de slides ocultos.

Os exemplos exigem Aspose.Slides for Python via Java e um runtime Java compatível. Coloque `pres.pptx` no diretório de trabalho atual. Cada exemplo inicia a JVM somente se ela ainda não estiver em execução.

## **Sobre XAML**

XAML é uma linguagem de marcação baseada em XML usada para descrever interfaces de usuário em frameworks como WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin.Forms.

Você pode trabalhar com arquivos XAML em um designer visual ou escrever e editar a marcação diretamente.

## **Exportar apresentações para XAML com opções padrão**

O exemplo Python a seguir mostra como exportar uma apresentação para XAML com as configurações padrão:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

Por padrão, os slides exportados são salvos em uma subpasta `pres` do diretório de trabalho atual do processo. A pasta é criada automaticamente e quaisquer imagens necessárias são salvas lá também.

O nome da pasta de saída é derivado do nome do arquivo fonte sem sua extensão. Para `pres.pptx`, os arquivos de saída são nomeados `pres/Slide_1.xaml`, `pres/Slide_2.xaml` e assim por diante. Mesmo que você passe um caminho absoluto para a apresentação de entrada, a pasta de saída é criada em relação ao diretório de trabalho atual, e não ao lado do arquivo de entrada.

## **Exportar apresentações para XAML com opções personalizadas**

Use a classe [XamlOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/xamloptions/) para controlar como Aspose.Slides exporta uma apresentação para XAML.

Para salvar a saída em um local personalizado, implemente `IXamlOutputSaver` e passe uma instância da sua implementação ao método [setOutputSaver](https://reference.aspose.com/slides/pt/python-java/aspose.slides/xamloptions/#setOutputSaver) de [XamlOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/xamloptions/).

Para incluir slides ocultos na saída XAML, chame [setExportHiddenSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) com `True`, conforme demonstrado no exemplo Python a seguir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Capturar todos os artefatos XAML gerados**

Uma exportação XAML pode gerar um documento XAML para cada slide exportado, além de imagens separadas e recursos de suporte. Atribua um `IXamlOutputSaver` personalizado ao [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/pt/python-java/aspose.slides/xamloptions/#setOutputSaver) para receber esses artefatos em vez de usar o salvador padrão do sistema de arquivos. Inicie a exportação com a sobrecarga XAML‑específica de [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save) que aceita opções XAML.

Em Python, use `jpype.JProxy` para implementar a interface Java `IXamlOutputSaver`. Converta o caminho de callback para `str` e copie o array de bytes Java para `bytes` Python antes de retorná‑lo, conforme demonstrado abaixo.

### **Entender o ciclo de vida do callback**

O exportador chama `IXamlOutputSaver.save` separadamente para cada artefato gerado:

- `path` identifica o artefato e pode incluir diretórios relativos. Preserve essa informação porque o XAML pode referenciar recursos usando caminhos relativos.
- `data` contém os bytes do artefato. Imagens e outros recursos binários não devem ser decodificados como texto.
- O salvador é responsável por reter ou persistir os dados antes de retornar. Os exemplos copiam cada array de bytes para memória controlada pela aplicação.
- Considere a exportação bem‑sucedida somente quando a operação de salvamento da apresentação retornar e cada callback for concluído com sucesso. Não sufoque erros de armazenamento nem inicie gravações em segundo plano não observadas. Se a persistência ocorrer posteriormente, relatar sucesso geral somente após essa etapa também for bem‑sucedida.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) também se aplica a um salvador personalizado. A configuração padrão, `False`, exclui documentos XAML de slides ocultos. Passar `True` inclui‑os e quaisquer recursos necessários à sua exportação. A contagem de recursos depende da apresentação; não presuma um callback por slide ou uma ordem fixa de callbacks.

### **Exportar para a memória e inspecionar os artefatos**

Este exemplo completo carrega `pres.pptx`, coleta cada artefato em um dicionário Python de nomes e valores `bytes` imutáveis, e imprime seu nome, tipo e contagem de bytes. Ele preserva os nomes fornecidos exatamente. Nomes duplicados tornam a coleção inválida em vez de sobrescrever silenciosamente um artefato. O exemplo verifica isso antes de usar os resultados.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(True)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    inspect_xaml_text = False
    image_extensions = (".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg")
    for name, data in saver.artifacts.items():
        lower_name = name.lower()
        is_xaml = lower_name.endswith(".xaml")
        is_image = lower_name.endswith(image_extensions)
        kind = "slide XAML" if is_xaml else "image" if is_image else "supporting resource"
        print(f"{name}: {len(data)} bytes ({kind})")

        # Decodifique apenas XAML, e somente quando a inspeção textual for necessária.
        if is_xaml and inspect_xaml_text:
            markup = data.decode("utf-8")
            print(markup)


main()
```

Verificações de extensão são úteis para inspeção; retenha todos os artefatos, incluindo tipos de recurso desconhecidos. Deixe os bytes inalterados ao armazenar ou transmitir. Use `bytes.decode` com UTF‑8 apenas para XAML que precise de processamento textual.

### **Empacotar artefatos coletados em um arquivo ZIP**

Este exemplo independente coleta a exportação, valida seus nomes e grava os bytes originais em um arquivo ZIP. Um nome de arquivo único separa trabalhos de exportação concorrentes. Entradas ZIP usam barras normais e mantêm diretórios relativos. Nomes inseguros ou que colidam após normalização rejeitam todo o pacote antes de ser escrito.

```python
from uuid import uuid4
from zipfile import ZipFile

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(False)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    entries = {}
    entry_names = set()
    for name, data in saver.artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name or "\x00" in entry_name
        unsafe_name |= any(not segment.strip() or segment in (".", "..") for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in entry_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        entry_names.add(normalized_name)
        entries[entry_name] = data

    job_id = uuid4()
    archive_path = f"xaml-{job_id}.zip"
    try:
        with ZipFile(archive_path, mode="x") as archive:
            for name, data in entries.items():
                archive.writestr(name, data)

        # Fechar finaliza o diretório ZIP antes que o sucesso seja relatado.
        print(f"Saved {len(entries)} artifacts to {archive_path}")
    except OSError as exception:
        print(f"Archive persistence failed: {exception}")


main()
```

O exemplo usa `zipfile.ZipFile` do Python para gravar um arquivo local; o exportador em si não grava arquivos XAML ou de imagem soltos. Para armazenamento remoto, substitua a etapa de gravação do arquivo por uploads dos arrays de bytes coletados. Use um identificador de trabalho de exportação mais o nome relativo completo do artefato como chave de blob, ou armazene o identificador do trabalho, o nome relativo e os dados binários em uma linha de banco de dados. Publique o trabalho somente após todos os uploads concluírem ou a transação do banco de dados for confirmada. Limpe a saída parcial se a persistência falhar.

Para apresentações grandes, um salvador personalizado pode persistir cada artefato diretamente no armazenamento da aplicação para evitar manter uma cópia adicional de toda a exportação na memória. Mantenha cada callback síncrono do ponto de vista do exportador: retorne somente após o destino aceitar os bytes e permita que falhas cheguem ao chamador.

### **Preservar nomes de recursos e verificar referências**

- Normalize separadores de caminho quando o destino exigir, mas preserve diretórios relativos. Não use apenas `pathlib.Path.name` a menos que cada nome gerado seja conhecido como único e as referências de recurso permaneçam válidas.
- Aplique validação de nomes específica ao destino. Ao escrever arquivos soltos, rejeite caminhos baseados em raiz e segmentos de travessia, resolva o destino com `pathlib.Path.resolve` e verifique se ele permanece abaixo do diretório de exportação pretendido, incluindo o separador de diretório na verificação de contenção. Use um diretório controlado pela aplicação sem links simbólicos que possam redirecionar gravações.
- Use um salvador e um namespace de armazenamento separados para cada trabalho de exportação. Detecte colisões após normalização de separadores e de acordo com as regras de sensibilidade à caixa do destino.
- Antes de publicar, analise cada documento XAML como XML e inspecione suas referências de recursos baseados em arquivo, como atributos `Source` ou `ImageSource` de imagens. Resolva cada URI relativo contra o diretório do artefato XAML que o contém, normalize o nome de armazenamento resultante e confirme que a chave de mapa correspondente, entrada ZIP ou objeto armazenado existe. Trate URIs externos e expressões de marcação XAML separadamente de nomes de arquivo relativos.

Por exemplo, se `pres/Slide_1.xaml` referencia `images/image1.png`, o recurso armazenado deve estar disponível como `pres/images/image1.png`. Manter apenas `image1.png` quebraria essa relação. Para armazenamento de objetos, preserve a mesma estrutura sob o prefixo do trabalho e torne essas URLs de recurso acessíveis ao consumidor XAML. Reabra o ZIP concluído para verificar nomes de entradas e bytes de recursos, e carregue slides representativos no ambiente XAML de destino para confirmar que as imagens são resolvidas corretamente.

## **Perguntas frequentes**

**Como garantir fontes previsíveis se a fonte original não estiver disponível na máquina?**

Chame [setDefaultRegularFont](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) em [XamlOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/xamloptions/) — ele é usado como fonte de fallback durante a exportação quando a original está ausente. Isso não garante que o XAML gerado referencie a fonte de fallback ou que a fonte esteja disponível na máquina alvo. Certifique‑se de que as fontes referenciadas pelo XAML estejam disponíveis no ambiente onde ele será exibido.

**O XAML exportado destina‑se apenas ao WPF ou pode ser usado em outras pilhas XAML também?**

Aspose.Slides exporta XAML WPF através de sua API pública. A compatibilidade com outras pilhas XAML, como UWP e Xamarin.Forms, não é garantida. Teste a marcação gerada no seu ambiente de destino.

**Slides ocultos são suportados e como impedir que sejam exportados por padrão?**

Por padrão, slides ocultos não são incluídos. Você pode controlar esse comportamento via [setExportHiddenSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) em [XamlOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/xamloptions/) — mantenha‑a desativada se não precisar exportá‑los.