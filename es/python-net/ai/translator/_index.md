---
title: Traductor de presentaciones impulsado por IA
linktitle: Traductor impulsado por IA
type: docs
weight: 20
url: /es/python-net/ai/translator/
keywords:
- Traductor de presentaciones con IA
- Traductor de diapositivas con IA
- Funcionalidad impulsada por IA
- Presentación multilingüe
- Diapositiva multilingüe
- Traducción de presentaciones
- Traducción de diapositivas
- Funciones basadas en IA
- Capacidades de IA
- Agente de IA
- Cliente Web
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Traduce diapositivas de PowerPoint con IA usando Aspose.Slides para Python. Localiza PPT, PPTX y ODP preservando el diseño—rápido y fácil para desarrolladores. Pruébalo."
---
## **Introducción**

Aspose.Slides es una API potente para gestionar presentaciones de PowerPoint de forma programática. Además de crear, editar y convertir diapositivas, ofrece funciones impulsadas por IA, como la [Presentation Translation API](https://reference.aspose.com/slides/es/python-net/aspose.slides.ai/) para contenido de diapositivas multilingüe.

## **Cómo funciona**

Aspose.Slides no incluye capacidades de IA integradas, pero se integra con modelos de IA externos a través de internet. Esta funcionalidad se expone mediante la clase [SlidesAIAgent](https://reference.aspose.com/slides/es/python-net/aspose.slides.ai/slidesaiagent/), que utiliza subclases de [IAIWebClient](https://reference.aspose.com/slides/es/python-net/aspose.slides.ai/iaiwebclient/) para comunicarse con los servicios de IA.

Puede utilizar el [OpenAIWebClient](https://reference.aspose.com/slides/es/python-net/aspose.slides.ai/openaiwebclient/) incorporado para conectar con la API de OpenAI o implementar su propio [IAIWebClient](https://reference.aspose.com/slides/es/python-net/aspose.slides.ai/iaiwebclient/) para usar otro proveedor de IA o modelo de lenguaje.

Aspose.Slides gestiona la comunicación, analiza las respuestas de la IA e inserta de forma inteligente el contenido traducido mientras preserva el diseño y formato original de la diapositiva.

{{% alert color="info" %}}
Tenga en cuenta que la API de OpenAI es un servicio de pago, por lo que deberá crear una cuenta y proporcionar su clave API al utilizar el [OpenAIWebClient](https://reference.aspose.com/slides/es/python-net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Ejemplo**

En este ejemplo, traducimos una presentación de PowerPoint al japonés utilizando el [OpenAIWebClient](https://reference.aspose.com/slides/es/python-net/aspose.slides.ai/openaiwebclient/) incorporado con un [modelo](https://platform.openai.com/docs/models) de OpenAI especificado.

```py
import aspose.slides as slides

# Cargar una presentación para traducir.
with slides.Presentation("sample.pptx") as presentation:

    # Crear un cliente de IA con OpenAIWebClient, especificando su modelo y clave API.
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # Inicializar SlidesAIAgent con el cliente de IA.
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # Traducir la presentación al japonés.
        ai_agent.translate(presentation, "japanese")

        # Guardar la presentación traducida como PDF.
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

### **Ejemplo de Azure OpenAI**

Desde la versión **26.7.0**, Aspose.Slides para Python a través de .NET admite proveedores compatibles con OpenAI, incluido Azure OpenAI. Puede configurar el traductor para usar su despliegue interno de Azure con el [OpenAICompatibleWebClient](https://reference.aspose.com/slides/es/python-net/aspose.slides.ai/openaicompatiblewebclient/).

```py
import aspose.slides as slides

model = "your-azure-deployment-name"
api_key = "your-azure-api-key"
base_url = "https://your-resource.openai.azure.com/openai/v1/"

with slides.ai.OpenAICompatibleWebClient(model, api_key, base_url) as ai_web_client:
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)
    with slides.Presentation("Presentation.pptx") as presentation:
        ai_agent.translate(presentation, "spanish")
        presentation.save("Translated.pptx", slides.export.SaveFormat.PPTX)
```

Este fragmento muestra cómo traducir una presentación usando su punto de conexión de Azure OpenAI. Reemplace los valores de marcador de posición con el nombre de su despliegue, la clave API y la URL del punto de conexión.

## **Ventajas clave**

La [Presentation Translation API](https://reference.aspose.com/slides/es/python-net/aspose.slides.ai/) de Aspose.Slides ofrece una solución impulsada por IA para ofrecer presentaciones de PowerPoint multilingües. Al automatizar la traducción mientras se preserva el diseño y la maquetación, ahorra tiempo y minimiza errores en comparación con los flujos de trabajo manuales. Tanto si es desarrollador, educador o profesional empresarial, esta API le permite crear presentaciones atractivas y localizadas para audiencias globales, ampliando su alcance y mejorando la comunicación.