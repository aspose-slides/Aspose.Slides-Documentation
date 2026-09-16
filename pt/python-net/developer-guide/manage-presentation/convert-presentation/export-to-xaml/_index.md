---
title: Exportar apresentações para XAML com Python
linktitle: Apresentação para XAML
type: docs
weight: 30
url: /pt/python-net/export-to-xaml/
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
- Aspose.Slides
description: "Converter slides PowerPoint e OpenDocument para XAML com Python usando Aspose.Slides - solução rápida, sem Office, que mantém seu layout intacto."
---
## **Visão geral**

Este artigo explica como exportar apresentações do PowerPoint para XAML usando Aspose.Slides. Inclui uma breve introdução ao XAML, mostra como salvar uma apresentação em XAML com as configurações padrão e demonstra como personalizar a exportação através de [XamlOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export.xaml/xamloptions/), incluindo a exportação de slides ocultos. O artigo também responde a algumas perguntas comuns relacionadas a fontes de fallback, compatibilidade de pilhas XAML e comportamento de exportação de slides ocultos.

## **Sobre XAML**

XAML é uma linguagem de marcação baseada em XML usada para descrever interfaces de usuário em estruturas como WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin.Forms.

Você pode trabalhar com arquivos XAML em um designer visual ou escrever e editar a marcação diretamente.

## **Exportar apresentações para XAML com opções padrão**

O exemplo Python a seguir mostra como exportar uma apresentação para XAML com as configurações padrão:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    presentation.save(xaml_options)
```

Por padrão, os slides exportados são salvos em uma subpasta `pres` do diretório de trabalho atual do processo, conforme retornado por [os.getcwd](https://docs.python.org/3/library/os.html#os.getcwd). A pasta é criada automaticamente e quaisquer imagens necessárias também são salvas lá.

O nome da pasta de saída é obtido a partir do nome do arquivo de origem sem sua extensão. Para `pres.pptx`, os arquivos de saída são nomeados `pres/Slide_1.xaml`, `pres/Slide_2.xaml` e assim por diante. Mesmo que você forneça um caminho absoluto para a apresentação de entrada, a pasta de saída é criada em relação ao diretório de trabalho atual, e não ao lado do arquivo de entrada.

## **Exportar apresentações para XAML com opções personalizadas**

Use a classe [XamlOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export.xaml/xamloptions/) para controlar como o Aspose.Slides exporta uma apresentação para XAML.

Para incluir slides ocultos na saída XAML, defina a propriedade [export_hidden_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) como `True`, como mostrado no exemplo Python a seguir:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    xaml_options.export_hidden_slides = True
    presentation.save(xaml_options)
```

## **Capturar todos os artefatos XAML gerados**

Uma exportação XAML pode gerar um documento XAML para cada slide exportado, além de imagens separadas e recursos de apoio. Mantenha todos esses arquivos ao armazenar ou transmitir uma exportação.

Os exemplos abaixo utilizam o salvador padrão de sistema de arquivos em um diretório temporário e, em seguida, coletam os arquivos gerados.

### **Entender o ciclo de vida da exportação**

- Inicie a exportação com a sobrecarga XAML‑específica de [Presentation.save](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/save/) que aceita opções XAML. Leia os arquivos gerados somente após o retorno bem‑sucedido.
- Preserve o caminho relativo de cada artefato porque o XAML pode referenciar recursos usando caminhos relativos.
- Leia os artefatos como bytes. Imagens e outros recursos binários não devem ser decodificados como texto.
- Relate o sucesso geral somente após a coleta e a conclusão de qualquer operação de armazenamento subsequente. Deixe que erros de armazenamento cheguem ao chamador e limpe a saída parcial se a persistência falhar.

[XamlOptions.export_hidden_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) tem padrão `False`, o que exclui documentos XAML de slides ocultos. Defini‑lo como `True` inclui-os e quaisquer recursos necessários para a exportação. A contagem de recursos depende da apresentação; não presuma um arquivo por slide.

{{% alert color="warning" title="Warning" %}}
Os exemplos alteram temporariamente o diretório de trabalho atual do processo, o que afeta todos os threads. Execute cada exportação em um processo worker dedicado ou garanta que nenhum outro trabalho no processo dependa do diretório atual durante a exportação. Um diretório temporário exclusivo, por si só, não torna as exportações concorrentes no mesmo processo seguras.
{{% /alert %}}

### **Exportar para memória e inspecionar os artefatos**

Este exemplo completo carrega `pres.pptx`, exporta‑o para um diretório temporário, coleta cada artefato em um dicionário de nomes relativos e bytes, e imprime seu nome, tipo e contagem de bytes. Ele preserva a estrutura de diretórios gerada e remove os arquivos temporários após a coleta. O caminho de entrada é resolvido antes de mudar o diretório de trabalho.

```python
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


artifacts = collect_xaml_artifacts("pres.pptx", True)
inspect_xaml_text = False
image_extensions = {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg"}
for name, data in artifacts.items():
    extension = Path(name).suffix.lower()
    if extension == ".xaml":
        kind = "slide XAML"
    elif extension in image_extensions:
        kind = "image"
    else:
        kind = "supporting resource"
    print(f"{name}: {len(data)} bytes ({kind})")

    # Decodificar apenas XAML, e somente quando for necessária a inspeção textual.
    if extension == ".xaml" and inspect_xaml_text:
        print(data.decode("utf-8"))
```

Verificações de extensão são úteis para inspeção; retenha todos os artefatos, incluindo tipos de recurso desconhecidos. Deixe os bytes inalterados ao armazenar ou transmitir. Decodifique apenas XAML que precise de processamento textual. Essa abordagem usa espaço em disco temporário além da memória para a exportação coletada.

### **Empacotar artefatos coletados em um arquivo ZIP**

Este exemplo independente coleta a exportação, valida seus nomes e grava os bytes originais em um arquivo ZIP. Um nome de arquivo único separa os trabalhos de exportação. Entradas ZIP usam barras normais e mantêm diretórios relativos. Nomes inseguros ou que colidem após a normalização rejeitam o pacote inteiro antes de ser gravado.

```python
from uuid import uuid4
from zipfile import ZIP_DEFLATED, ZipFile
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


def package_xaml():
    artifacts = collect_xaml_artifacts("pres.pptx", False)
    entries = {}
    normalized_names = set()
    for name, data in artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name
        unsafe_name = unsafe_name or any(not segment.strip() or segment in {".", ".."} for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in normalized_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        normalized_names.add(normalized_name)
        entries[entry_name] = data

    archive_path = Path(f"xaml-{uuid4().hex}.zip")
    with ZipFile(archive_path, "x", compression=ZIP_DEFLATED) as archive:
        for name, data in entries.items():
            archive.writestr(name, data)

    # O diretório ZIP foi finalizado antes de relatar o sucesso.
    print(f"Saved {len(entries)} artifacts to {archive_path}")


package_xaml()
```

O exemplo usa [ZipFile](https://docs.python.org/3/library/zipfile.html#zipfile.ZipFile) para gravar um arquivo local após coletar a exportação temporária. Para armazenamento remoto, substitua a etapa de gravação do arquivo por uploads dos bytes coletados. Use um identificador de job de exportação mais o nome relativo completo do artefato como chave de objeto, ou armazene o identificador do job, o nome relativo e os dados binários em uma linha de banco de dados. Publique o job somente após todos os uploads concluírem ou a transação do banco for confirmada. Limpe a saída parcial se a persistência falhar.

Para apresentações grandes, processe os arquivos temporários um de cada vez após a exportação ao invés de coletar todos os bytes em um dicionário. Isso evita uma cópia adicional em memória de toda a exportação, mas não elimina os requisitos de memória do próprio exportador.

### **Preservar nomes de recursos e verificar referências**

- Normalize separadores de caminho quando o destino exigir, mas preserve diretórios relativos. Não mantenha apenas o nome final do arquivo a menos que cada nome gerado seja conhecido como único e as referências de recurso permaneçam válidas.
- Aplique validação de nomes específica ao destino. Ao gravar arquivos soltos, rejeite caminhos absolutos e segmentos de travessia, resolva o destino e verifique se ele permanece dentro do diretório de exportação pretendido. Use um diretório controlado pela aplicação sem links simbólicos que possam redirecionar gravações.
- Use um namespace de armazenamento separado para cada job de exportação. Detecte colisões após a normalização de separadores e de acordo com as regras de sensibilidade a maiúsculas/minúsculas do destino.
- Antes de publicar, analise cada documento XAML como XML e inspecione suas referências de recursos baseadas em arquivos, como atributos `Source` ou `ImageSource` de imagens. Resolva cada URI relativo contra o diretório do artefato XAML que o contém, normalize o nome de armazenamento resultante e confirme que a chave correspondente no dicionário, a entrada ZIP ou o objeto armazenado existe. Trate URIs externos e expressões de marcação XAML separadamente de nomes de arquivo relativos.

Por exemplo, se `pres/Slide_1.xaml` referenciar `images/image1.png`, o recurso armazenado deve estar disponível como `pres/images/image1.png`. Manter apenas `image1.png` quebraria essa relação. Para armazenamento de objetos, preserve o mesmo layout sob o prefixo do job e torne essas URLs de recursos acessíveis ao consumidor XAML. Reabra o ZIP concluído para verificar nomes de entradas e bytes de recursos, e carregue slides representativos no ambiente XAML de destino para confirmar que as imagens são resolvidas corretamente.

## **Perguntas frequentes**

**Como posso garantir fontes previsíveis se a fonte original não estiver disponível na máquina?**

Defina [default_regular_font](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) em [XamlOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export.xaml/xamloptions/) — ele é usado como fonte de fallback durante a exportação quando a original está ausente. Isso não garante que o XAML gerado referencie a fonte de fallback ou que a fonte esteja disponível na máquina de destino. Garanta que as fontes referenciadas pelo XAML estejam disponíveis no ambiente onde ele será exibido.

**O XAML exportado destina‑se apenas ao WPF ou pode ser usado em outras pilhas XAML também?**

Aspose.Slides exporta XAML para WPF através de sua API pública. A compatibilidade com outras pilhas XAML, como UWP e Xamarin.Forms, não é garantida. Teste a marcação gerada no seu ambiente de destino.

**Slides ocultos são suportados e como posso impedir que sejam exportados por padrão?**

Por padrão, slides ocultos não são incluídos. Você pode controlar esse comportamento via [export_hidden_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) em [XamlOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export.xaml/xamloptions/) — mantenha‑a desativada se não precisar exportá‑los.