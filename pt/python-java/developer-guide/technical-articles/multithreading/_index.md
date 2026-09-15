---
title: Multithreading no Aspose.Slides para Python via Java
linktitle: Multithreading
type: docs
weight: 310
url: /pt/python-java/multithreading/
keywords:
- multithreading
- várias threads
- trabalho paralelo
- converter slides
- slides para imagens
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "O multithreading do Aspose.Slides para Python via Java aumenta o processamento de PowerPoint e OpenDocument. Descubra as melhores práticas para fluxos de trabalho de apresentações eficientes."
---
## **Introduction**

Embora o trabalho em paralelo com apresentações seja possível (exceto para análise, carregamento e clonagem) e geralmente funcione bem, há uma pequena chance de resultados incorretos ao usar a biblioteca em múltiplas threads.

Recomendamos fortemente que você **não** use uma única instância de [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) em um ambiente multithread, pois isso pode gerar erros ou falhas imprevisíveis que não são facilmente detectados.

Não é **seguro** carregar, salvar e/ou clonar uma instância de [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) em múltiplas threads. Essas operações **não** são suportadas. Se precisar executar tais tarefas, você deve paralelizar as operações usando vários processos de thread única — e cada um desses processos deve usar sua própria instância de apresentação.

## **Convert Presentation Slides to Images in Parallel**

Suponha que queiramos converter todos os slides de uma apresentação PowerPoint em imagens PNG em paralelo. Como não é seguro usar uma única instância de [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) em múltiplas threads, dividimos os slides da apresentação em apresentações separadas e convertemos os slides em imagens em paralelo, usando cada apresentação em uma thread distinta. O exemplo de código a seguir mostra como fazer isso.

```python
from concurrent.futures import ThreadPoolExecutor

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, SlideSizeScaleType


input_file_path = "sample.pptx"
output_file_path_template = "slide_{}.png"
image_scale = 2.0


def convert_slide_to_image(slide_presentation, slide_number):
    try:
        slide = slide_presentation.getSlides().get_Item(0)
        image = slide.getImage(image_scale, image_scale)
        try:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.Png)
        finally:
            image.dispose()
    finally:
        slide_presentation.dispose()


presentation = Presentation(input_file_path)
try:
    slide_count = presentation.getSlides().size()
    slide_size = presentation.getSlideSize().getSize()
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())

    with ThreadPoolExecutor() as executor:
        conversion_tasks = []
        for slide_index in range(slide_count):
            # Extraia o slide para uma apresentação separada.
            slide_presentation = Presentation()
            slide_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)
            slide_presentation.getSlides().removeAt(0)
            slide_presentation.getSlides().addClone(presentation.getSlides().get_Item(slide_index))

            # Converta o slide em uma imagem em uma tarefa separada.
            slide_number = slide_index + 1
            conversion_task = executor.submit(convert_slide_to_image, slide_presentation, slide_number)
            conversion_tasks.append(conversion_task)

        # Aguarde a conclusão de todas as tarefas.
        for conversion_task in conversion_tasks:
            conversion_task.result()
finally:
    presentation.dispose()
```

## **FAQ**

**Do I need to call license setup in every thread?**

**Preciso chamar a configuração de licença em cada thread?**

Não. Basta fazê‑lo uma vez por processo antes que as threads iniciem. Se a [license setup](/slides/pt/python-java/licensing/) puder ser invocada simultaneamente (por exemplo, durante a inicialização preguiçosa), sincronize essa chamada, pois o método de configuração de licença em si não é thread‑safe.

**Can I pass [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) or [Slide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/) objects between threads?**

**Posso passar objetos [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) ou [Slide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/) entre threads?**

Passar objetos de apresentação “vivos” entre threads não é recomendado: use instâncias independentes por thread ou crie apresentações ou contêineres de slides separados para cada thread antecipadamente. Essa abordagem segue a recomendação geral de não compartilhar uma única instância de apresentação entre threads.

**Is it safe to parallelize export to different formats (PDF, HTML, images) provided each thread has its own [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) instance?**

**É seguro paralelizar a exportação para diferentes formatos (PDF, HTML, imagens) desde que cada thread tenha sua própria instância de [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/)?**

Sim. Com instâncias independentes e caminhos de saída separados, essas tarefas normalmente são paralelizadas corretamente; evite qualquer objeto de apresentação compartilhado e fluxos de I/O compartilhados.

**What should I do with global font settings (folders, substitutions) in multithreading?**

**O que devo fazer com as configurações globais de fontes (pastas, substituições) em multithreading?**

Inicialize todas as [font settings](/slides/pt/python-java/powerpoint-fonts/) globais antes de iniciar as threads e não as altere durante o trabalho paralelo. Isso elimina condições de corrida ao acessar recursos de fontes compartilhados.