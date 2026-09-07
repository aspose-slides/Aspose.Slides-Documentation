---
title: Converter PPT para PPTX em Python
linktitle: PPT para PPTX
type: docs
weight: 20
url: /pt/python-java/convert-ppt-to-pptx/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- PPT para PPTX
- salvar PPT como PPTX
- exportar PPT para PPTX
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Converta arquivos PPT legados para PPTX em Python com Aspose.Slides. Inclui exemplos em Python para conversão de um único arquivo e em lote, tratamento de erros e notas sobre fidelidade."
---
## **Visão geral**

PPT é o formato binário legado do PowerPoint, enquanto PPTX é o formato Open XML mais recente. Aspose.Slides for Python via Java pode carregar um arquivo PPT e salvá‑lo como PPTX sem o Microsoft PowerPoint. Este artigo mostra como converter um arquivo ou um diretório de arquivos e explica o que verificar após a conversão.

Cada exemplo inicia a máquina virtual Java, se necessário, e libera a apresentação após o uso. Substitua os caminhos de exemplo pelos seus próprios caminhos de arquivo ou diretório.

## **Converter um arquivo PPT para PPTX**

Carregue o arquivo de origem com a classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/), depois chame [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save) com [SaveFormat.Pptx](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveformat/#Pptx). O bloco `finally` libera a apresentação e seus recursos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Carregue a apresentação PPT legada.
presentation = Presentation("presentation.ppt")
try:
    # Salve a apresentação no formato PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A extensão do arquivo não seleciona o formato de saída por si só; o argumento [SaveFormat.Pptx](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveformat/#Pptx) faz isso. Mantenha os caminhos de entrada e saída diferentes se precisar preservar o arquivo PPT original.

## **Converter vários arquivos PPT**

O exemplo a seguir converte todos os arquivos `.ppt` de um diretório. Cada arquivo é processado de forma independente, de modo que uma falha de conversão não interrompe o restante do lote.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input_directory = Path("input")
output_directory = Path("output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
    input_files = list(input_directory.iterdir())
except OSError as error:
    print(f"Cannot prepare the conversion directories: {error}")
else:
    for input_file in input_files:
        if not input_file.is_file() or input_file.suffix.lower() != ".ppt":
            continue

        output_file = output_directory / (input_file.stem + ".pptx")
        input_path = str(input_file)
        output_path = str(output_file)
        presentation = None

        try:
            presentation = Presentation(input_path)
            presentation.save(output_path, SaveFormat.Pptx)
            print(f"Converted: {input_path}")
        except Exception as error:
            print(f"Failed: {input_path} ({error})")
        finally:
            if presentation is not None:
                presentation.dispose()
```

Para cargas de trabalho de produção, registre a exceção completa, decida se um arquivo de saída existente pode ser sobrescrito e escreva os nomes dos arquivos que falharam em uma fila de reprocessamento ou revisão. Arquivos corrompidos, arquivos protegidos por senha abertos sem a senha necessária, caminhos inacessíveis e conteúdo não suportado podem causar falha na conversão. Consulte [Apresentações protegidas por senha](/slides/pt/python-java/password-protected-presentation/) para carregar arquivos criptografados.

## **Fidelidade e recursos legados**

A conversão normalmente preserva slides, mestres, layouts, texto, formas, imagens, tabelas e gráficos. Contudo, PPT e PPTX não representam todos os recursos da mesma forma. Um recurso legado que não tem equivalente em PPTX, ou que não é suportado pela biblioteca, pode ser normalizado, omitido ou exibido de forma diferente.

Verifique o arquivo convertido quando ele contiver animações, transições, objetos OLE incorporados ou vinculados, controles ActiveX, mídia incorporada, fontes incomuns ou macros VBA. Um arquivo PPTX simples não habilita macros, portanto use um fluxo de trabalho apropriado para macros quando VBA precisar permanecer disponível. Também verifique se as fontes necessárias e os recursos externos estão presentes no ambiente onde a apresentação convertida será aberta ou renderizada.

Para documentos importantes, reabra o PPTX gerado programaticamente e inspecione contagens e conteúdo de slides-chave, depois compare sua aparência e comportamento de apresentação no visualizador pretendido. Não considere uma chamada bem‑sucedida a [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save) como prova de que todos os recursos legados têm representação exata em PPTX.

## **Quando usar PPTX**

Use PPTX quando a apresentação for editada nas versões atuais do PowerPoint, trocada com sistemas que trabalham com pacotes Open XML ou armazenada em um formato mais fácil de inspeção e recuperação que o binário legado PPT. Mantenha o PPT original como cópia de arquivamento ou de rollback até que a apresentação convertida passe em seus testes de fidelidade.

Se precisar de PDF, HTML, imagens, XPS ou outro tipo de saída, use as orientações específicas de formato em [Converter apresentações para vários formatos](/slides/pt/python-java/convert-presentation/) em vez de supor que todos os destinos preservam recursos editáveis do PowerPoint.

## **Conversor online**

Para um arquivo ocasional ou uma comparação rápida, você pode usar o [conversor online de PPT para PPTX](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx). Para conversões repetíveis, processamento em lote ou tratamento de erros em nível de aplicação, use a API Python via Java.

## **Artigos relacionados**

- [PPT vs PPTX](/slides/pt/python-java/ppt-vs-pptx/)
- [Salvar apresentações em Python](/slides/pt/python-java/save-presentation/)
- [Formatos de arquivo suportados](/slides/pt/python-java/supported-file-formats/)
- [Abrir apresentações em Python](/slides/pt/python-java/open-presentation/)

## **FAQ**

**Posso converter PPT para PPTX sem o Microsoft PowerPoint instalado?**

Sim. Aspose.Slides for Python via Java carrega e salva arquivos de apresentação sem necessitar do Microsoft PowerPoint.

**A conversão de PPT para PPTX preservará todo o conteúdo exatamente?**

Ela preserva o conteúdo de apresentação comum, mas a fidelidade exata não é garantida para cada recurso legado ou não suportado. Revise o arquivo gerado quando ele contiver macros, objetos OLE ou ActiveX, mídia, animações especializadas ou fontes incomuns.

**Posso converter um arquivo PPT protegido por senha?**

Sim, se você fornecer a senha correta ao carregar o arquivo. Falta ou senha incorreta faz a operação de carregamento falhar.

**Devo excluir o arquivo PPT após a conversão?**

Mantenha o original até que você tenha verificado o PPTX nos visualizadores e fluxos de trabalho que são importantes para você. Isso fornece uma cópia de rollback caso um recurso legado seja convertido de forma diferente.