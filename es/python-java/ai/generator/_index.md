---
title: Generador de diapositivas multilingüe impulsado por IA
linktitle: Generador impulsado por IA
type: docs
weight: 40
url: /es/python-java/ai/generator/
keywords:
- presentación multilingüe
- diapositiva multilingüe
- generador de presentaciones IA
- generador de diapositivas IA
- plantilla de presentación
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Cree presentaciones multilingües a partir de texto con Aspose.Slides para Python mediante Java. Elija el nivel de detalle del contenido, aplique una plantilla y exporte a PowerPoint o PDF."
---
## **Introducción**

El Generador de presentaciones IA en Aspose.Slides for Python via Java crea presentaciones a partir de descripciones de temas, resúmenes, citas o viñetas. Indique el idioma requerido en su solicitud, elija la cantidad de contenido y, opcionalmente, proporcione una plantilla de presentación para definir la maquetación y el diseño.

El generador estructura el contenido usando bloques de texto, listas con viñetas y tablas. No genera imágenes; puede añadirlas a la presentación resultante posteriormente. Revise el contenido y la maquetación generados antes de compartir la presentación.

## **Cómo funciona**

[SlidesAIAgent](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidesaiagent/) utiliza un cliente IA para comunicarse con un modelo externo. Los ejemplos a continuación usan el [OpenAIWebClient](https://reference.aspose.com/slides/es/python-java/aspose.slides/openaiwebclient/) incorporado. Aspose.Slides procesa las respuestas del modelo y construye una presentación que puede editar o exportar.

Utilice [SlidesAIAgent.generatePresentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidesaiagent/#generatePresentation) con una descripción de texto y un valor de [PresentationContentAmountType](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationcontentamounttype/). La sobrecarga con un tercer argumento acepta una presentación para usar como plantilla de diseño.

## **Requisitos previos**

Siga la [Installation](/slides/es/python-java/installation/) para configurar Python, Java, JPype y Aspose.Slides. Establezca las variables de entorno `OPENAI_API_KEY` y `OPENAI_MODEL` antes de ejecutar los ejemplos. Elija un modelo compatible con el cliente incorporado y disponible para su cuenta de API.

{{% alert color="info" title="Nota" %}}

El servicio IA requiere una conexión a Internet y acceso API independiente. Las solicitudes se envían al servicio configurado, y sus cargos de uso se aplican de forma independiente de su licencia de Aspose.Slides.

{{% /alert %}}

Cada ejemplo inicia la JVM solo si aún no está en ejecución y la deja disponible para operaciones posteriores. Consulte la [JVM lifecycle guidance](/slides/es/python-java/limitations-and-api-differences/#import-the-library) al adaptar el código para cuadernos.

## **Generar una presentación a partir de texto**

Este ejemplo genera una presentación en inglés con una cantidad de contenido [Medium](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationcontentamounttype/#Medium) y la guarda como un archivo PowerPoint.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    instruction = "Generate an English presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
    presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Medium)
    try:
        presentation.save("generated.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **Generar una presentación usando una plantilla**

Coloque `masterPresentation.pptx` en el directorio de trabajo. Este ejemplo lo carga con [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/), genera una presentación en español con contenido [Detailed](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationcontentamounttype/#Detailed) y la exporta a PDF. Tanto la plantilla como la presentación generada se liberan, incluso si la generación o el guardado fallan.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    template = Presentation("masterPresentation.pptx")
    try:
        instruction = "Generate a Spanish presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
        presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Detailed, template)
        try:
            presentation.save("generated.pdf", SaveFormat.Pdf)
        finally:
            presentation.dispose()
    finally:
        template.dispose()
finally:
    ai_client.close()
```

Si necesita configurar un proxy o tiempos de espera de conexión, vea [Configure the HTTP Connection](/slides/es/python-java/ai/translator/#configure-the-http-connection). También puede pasar el cliente resultante al generador.

## **Ventajas clave**

La generación puede reducir el trabajo inicial de redacción para materiales de formación, resúmenes de productos, informes para clientes y presentaciones internas. Las solicitudes controlan el tema y el idioma, mientras que una plantilla le permite reutilizar un diseño de presentación existente.

## **Preguntas frecuentes**

**¿Cómo controlo la longitud de la presentación generada?**

Elija [Brief](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationcontentamounttype/#Brief), [Medium](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationcontentamounttype/#Medium) o [Detailed](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationcontentamounttype/#Detailed). Estas configuraciones influyen tanto en el número de diapositivas como en el detalle de cada una; no especifican un recuento exacto de diapositivas.

**¿Puedo generar diapositivas en otro idioma?**

Sí. Incluya el idioma solicitado en la descripción de texto. El resultado depende de las capacidades lingüísticas del modelo seleccionado.

**¿Puedo conservar una versión editable al exportar a PDF?**

Sí. Antes de desechar la presentación generada, guárdela también como PPTX usando el enfoque del primer ejemplo.