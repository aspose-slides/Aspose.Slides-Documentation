---
title: Converter PPT para PPTX em Python
linktitle: PPT para PPTX
type: docs
weight: 20
url: /pt/python-net/convert-ppt-to-pptx/
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
- Aspose.Slides
description: "Converter arquivos PPT legados para PPTX em Python com Aspose.Slides. Inclui exemplos para conversão de arquivo único e em lote, tratamento de erros e notas de fidelidade."
---
## **Visão geral**

PPT é o formato binário legado do PowerPoint, enquanto PPTX é o formato Open XML mais recente. Aspose.Slides for Python via .NET pode carregar um arquivo PPT e salvá‑lo como PPTX sem o Microsoft PowerPoint. Este artigo mostra como converter um arquivo ou um diretório de arquivos e explica o que verificar após a conversão.

## **Converter um arquivo PPT para PPTX**

Carregue o arquivo de origem com a classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e, em seguida, chame [Presentation.save](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/save/) passando [SaveFormat.PPTX](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/saveformat/). A instrução `with` libera a apresentação e seus recursos quando o bloco termina.

```python
import aspose.slides as slides

# Carregar a apresentação PPT legada.
with slides.Presentation("presentation.ppt") as presentation:
    # Salvar a apresentação no formato PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

A extensão do arquivo não seleciona o formato de saída por si só; o argumento [SaveFormat.PPTX](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/saveformat/) faz isso. Mantenha os caminhos de entrada e saída diferentes se precisar preservar o arquivo PPT original.

## **Converter vários arquivos PPT**

O exemplo a seguir converte cada arquivo `.ppt` em um diretório. Cada arquivo é processado independentemente, de modo que uma conversão com falha não interrompe o restante do lote.

```python
from pathlib import Path

import aspose.slides as slides

input_directory = Path("input")
output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

for input_path in input_directory.glob("*.ppt"):
    output_path = output_directory / f"{input_path.stem}.pptx"

    try:
        with slides.Presentation(str(input_path)) as presentation:
            presentation.save(str(output_path), slides.export.SaveFormat.PPTX)
        print(f"Converted: {input_path}")
    except Exception as exception:
        print(f"Failed: {input_path} ({exception})")
```

Para cargas de trabalho de produção, registre a exceção completa, decida se um arquivo de saída existente pode ser sobrescrito e grave os nomes dos arquivos que falharam em uma fila de nova tentativa ou revisão. Arquivos corrompidos, arquivos protegidos por senha abertos sem a senha correta, caminhos inacessíveis e conteúdo não suportado podem fazer a conversão falhar. Consulte [Password-Protected Presentations](/slides/pt/python-net/password-protected-presentation/) para carregar arquivos criptografados.

## **Fidelidade e recursos legados**

A conversão normalmente preserva slides, mestres, layouts, texto, formas, imagens, tabelas e gráficos. No entanto, PPT e PPTX não representam todos os recursos exatamente da mesma maneira. Um recurso legado que não tem equivalente PPTX ou que não é suportado pela biblioteca pode ser normalizado, omitido ou exibido de forma diferente.

Verifique o arquivo convertido quando ele contiver animações, transições, objetos OLE incorporados ou vinculados, controles ActiveX, mídia incorporada, fontes incomuns ou macros VBA. Um arquivo PPTX simples não é um formato que aceita macros, portanto use um fluxo de trabalho adequado a macros quando o VBA precisar permanecer disponível. Também verifique se as fontes necessárias e os recursos externos estão presentes no ambiente onde a apresentação convertida será aberta ou renderizada.

Para documentos importantes, reabra o PPTX gerado programaticamente e inspecione contagens e conteúdo de slides chave, depois compare sua aparência e comportamento de exibição de slides no visualizador pretendido. Não trate uma chamada bem‑sucedida a [Presentation.save](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/save/) como prova de que cada recurso legado tem uma representação PPTX exata.

## **Quando usar PPTX**

Use PPTX quando a apresentação será editada nas versões atuais do PowerPoint, trocada com sistemas que trabalham com pacotes Open XML ou armazenada em um formato mais fácil de inspecionar e recuperar do que o binário legado PPT. Mantenha o PPT original como cópia de arquivamento ou rollback até que a apresentação convertida passe em suas verificações de fidelidade.

Se precisar de PDF, HTML, imagens, XPS ou outro tipo de saída, utilize as orientações específicas de formato em [Convert Presentations to Multiple Formats](/slides/pt/python-net/convert-presentation/) em vez de presumir que todos os destinos preservam recursos editáveis do PowerPoint.

## **Conversor online**

Para um arquivo ocasional ou uma comparação rápida, você pode usar o [online PPT to PPTX converter](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx). Para conversões repetíveis, processamento em lote ou tratamento de erros em nível de aplicação, use a API Python.

## **Artigos relacionados**

- [PPT vs PPTX](/slides/pt/python-net/ppt-vs-pptx/)
- [Salvar apresentações em Python](/slides/pt/python-net/save-presentation/)
- [Formatos de arquivo suportados](/slides/pt/python-net/supported-file-formats/)
- [Abrir apresentações em Python](/slides/pt/python-net/open-presentation/)

## **FAQ**

**Posso converter PPT para PPTX sem o Microsoft PowerPoint instalado?**

Sim. Aspose.Slides for Python via .NET carrega e salva arquivos de apresentação sem exigir o Microsoft PowerPoint.

**A conversão de PPT para PPTX preservará todo o conteúdo exatamente?**

Ela preserva o conteúdo comum da apresentação, mas a fidelidade exata não é garantida para cada recurso legado ou não suportado. Revise o arquivo gerado quando ele contiver macros, objetos OLE ou ActiveX, mídia, animações especializadas ou fontes incomuns.

**Posso converter um arquivo PPT protegido por senha?**

Sim, se você fornecer a senha correta ao carregar o arquivo. Uma senha ausente ou incorreta faz a operação de carregamento falhar.

**Devo excluir o arquivo PPT após a conversão?**

Mantenha o original até verificar o PPTX nos visualizadores e fluxos de trabalho que são importantes para você. Isso fornece uma cópia de rollback caso um recurso legado seja convertido de forma diferente.