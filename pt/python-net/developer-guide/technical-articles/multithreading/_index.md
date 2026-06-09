---
title: Multithreading no Aspose.Slides para Python
linktitle: Multithreading
type: docs
weight: 200
url: /pt/python-net/multithreading/
keywords:
- multithreading
- múltiplas threads
- trabalho paralelo
- converter slides
- slides para imagens
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Aspose.Slides para Python via multithreading .NET acelera o processamento de PowerPoint e OpenDocument. Descubra as melhores práticas para fluxos de trabalho de apresentações eficientes."
---
## **Introdução**

Embora o trabalho paralelo com apresentações seja possível (além de parsing/loading/cloning) e tudo funcione bem (na maioria das vezes), há uma pequena chance de obter resultados incorretos ao usar a biblioteca em múltiplas threads.

Recomendamos enfaticamente que **não** use uma única instância de [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) em um ambiente de multithreading, pois isso pode resultar em erros ou falhas imprevisíveis que não são facilmente detectados. 

Não é seguro carregar, salvar e/ou clonar uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) em várias threads. Essas operações **não** são suportadas. Se precisar executar tais tarefas, você deve paralelizar as operações usando vários processos de thread única — e cada um desses processos deve usar sua própria instância de apresentação. 

## **Converter Slides de Apresentação em Imagens em Paralelo**

Suponhamos que queremos converter todos os slides de uma apresentação PowerPoint em imagens PNG em paralelo. Como é inseguro usar uma única instância `Presentation` em múltiplas threads, dividimos os slides da apresentação em apresentações separadas e convertemos os slides em imagens em paralelo, usando cada apresentação em uma thread distinta. O exemplo de código a seguir mostra como fazer isso.

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # Extrair o slide i em uma apresentação separada.
    with Presentation() as slide_presentation:
        slide_presentation.slide_size.set_size(slide_size.width, slide_size.height, SlideSizeScaleType.DO_NOT_SCALE)
        slide_presentation.slides.remove_at(0)
        slide_presentation.slides.add_clone(presentation.slides[slide_index])

        slide_number = slide_index + 1
        slide = slide_presentation.slides[0]

        # Converter o slide em uma imagem.
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# Aguardar a conclusão de todas as tarefas.
for task in conversion_tasks:
    task.result()

del presentation
```

## **FAQ**

**Preciso chamar a configuração de licença em cada thread?**

Não. Basta fazê‑lo uma vez por processo/domínio de aplicação antes de as threads iniciarem. Se a [license setup](/slides/pt/python-net/licensing/) puder ser invocada simultaneamente (por exemplo, durante a inicialização preguiçosa), sincronize essa chamada porque o método de configuração de licença não é thread‑safe.

**Posso passar objetos `Presentation` ou `Slide` entre threads?**

Passar objetos de apresentação “vivos” entre threads não é recomendado: use instâncias independentes por thread ou crie apresentações/containers de slide separados previamente para cada thread. Essa abordagem segue a recomendação geral de não compartilhar uma única instância de apresentação entre threads.

**É seguro paralelizar a exportação para diferentes formatos (PDF, HTML, images) desde que cada thread tenha sua própria instância `Presentation`?**

Sim. Com instâncias independentes e caminhos de saída separados, essas tarefas normalmente são paralelizadas corretamente; evite qualquer objeto de apresentação compartilhado e fluxos de I/O compartilhados.

**O que devo fazer com as configurações globais de fontes (pastas, substituições) em multithreading?**

Inicialize todas as configurações globais de fontes antes de iniciar as threads e não as altere durante o trabalho paralelo. Isso elimina condições de corrida ao acessar recursos de fontes compartilhados.