---
title: Traductor de presentaciones impulsado por IA
linktitle: Traductor impulsado por IA
type: docs
weight: 20
url: /es/python-java/ai/translator/
keywords:
- traductor de presentaciones con IA
- traductor de diapositivas con IA
- presentación multilingüe
- traducción de presentaciones
- traducción de diapositivas
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Traduce presentaciones con IA usando Aspose.Slides para Python a través de Java. Localiza el texto de las diapositivas y guarda la presentación traducida como PowerPoint o PDF."
---
## **Introducción**

Aspose.Slides for Python via Java ofrece una API de traducción de presentaciones con IA para localizar el contenido de las diapositivas. Traduce una presentación existente a un idioma especificado y guarda la versión traducida en el formato que necesita tu audiencia.

## **Cómo funciona**

[SlidesAIAgent](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidesaiagent/) se comunica con un servicio de IA externo a través de un cliente de IA. Los ejemplos usan el [OpenAIWebClient](https://reference.aspose.com/slides/es/python-java/aspose.slides/openaiwebclient/) incorporado.

[SlidesAIAgent.translate](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidesaiagent/#translate) actualiza la presentación que se le pasa. Aspose.Slides procesa las respuestas de IA y reemplaza el texto de las diapositivas manteniendo el diseño y formato existentes. Revisa el resultado: el texto traducido puede ser más largo que el original y requerir ajustes de diseño.

## **Requisitos previos**

Sigue la guía de [Installation](/slides/es/python-java/installation/) para configurar la biblioteca y su tiempo de ejecución. Define las variables de entorno `OPENAI_API_KEY` y `OPENAI_MODEL` antes de ejecutar los ejemplos. Elige un modelo compatible con el cliente incorporado y disponible para tu cuenta de API.

{{% alert color="info" title="Note" %}}

Translation requires an internet connection and sends presentation text to the configured AI service. Its API access and usage charges are separate from your Aspose.Slides license.

{{% /alert %}}

Los ejemplos reutilizan una JVM activa o la inician si es necesario. Consulta la [JVM lifecycle guidance](/slides/es/python-java/limitations-and-api-differences/#import-the-library) para el uso en cuadernos.

## **Traducir una presentación**

Coloca `sample.pptx` en el directorio de trabajo. Este ejemplo lo carga con [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/), traduce su texto al japonés y guarda el resultado como PDF. Libera la presentación y cierra el cliente de IA incluso si una operación falla.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    presentation = Presentation("sample.pptx")
    try:
        ai_agent = SlidesAIAgent(ai_client)
        ai_agent.translate(presentation, "Japanese")
        presentation.save("sample_ja.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **Configurar la conexión HTTP**

Por defecto, [OpenAIWebClient](https://reference.aspose.com/slides/es/python-java/aspose.slides/openaiwebclient/) gestiona su conexión HTTP internamente. Su constructor de cuatro argumentos también acepta un [HttpURLConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/HttpURLConnection.html) Java gestionado externamente. Usa esta sobrecarga cuando necesites configurar un proxy o tiempos de espera de la conexión.

El siguiente ejemplo crea un proxy HTTP Java con [Proxy](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/Proxy.html) y abre una conexión mediante [URL.openConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/URL.html#openConnection(java.net.Proxy)). Sustituye `proxy.example.com` y el puerto por la configuración de tu proxy. La conexión se pasa directamente a través de JPype; una sesión HTTP de Python no puede usarse en su lugar.

```python
import os
import jpype
import jpype.imports
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.net import InetSocketAddress, Proxy, URL
from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
proxy_address = InetSocketAddress("proxy.example.com", 8080)
proxy = Proxy(Proxy.Type.HTTP, proxy_address)
endpoint = URL("https://api.openai.com/v1/chat/completions")
connection = endpoint.openConnection(proxy)
try:
    connection.setConnectTimeout(30000)
    connection.setReadTimeout(60000)
    ai_client = OpenAIWebClient(model, api_key, None, connection)
    try:
        presentation = Presentation("sample.pptx")
        try:
            ai_agent = SlidesAIAgent(ai_client)
            ai_agent.translate(presentation, "Japanese")
            presentation.save("sample_ja.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        ai_client.close()
finally:
    connection.disconnect()
```

## **Ventajas clave**

La traducción automática ayuda a preparar materiales de formación multilingües, presentaciones de productos e informes para clientes mientras se reutiliza el diseño de diapositivas existente. Guarda una presentación editable para una revisión posterior o exporta un PDF para su distribución.

## **FAQ**

**¿La traducción crea un objeto de presentación independiente?**

No. [SlidesAIAgent.translate](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidesaiagent/#translate) modifica la presentación suministrada. Guárdala con un nombre de archivo nuevo para mantener el archivo original sin cambios.

**¿Cómo se especifica el idioma de destino?**

Pasa el nombre del idioma, como `"Japanese"` o `"Spanish"`, como segundo argumento. La calidad de la traducción y la cobertura de idiomas dependen del modelo seleccionado.

**¿Puedo traducir sin usar un proxy?**

Sí. Utiliza el constructor del cliente de tres argumentos mostrado en el primer ejemplo. El ejemplo de conexión personalizada solo es necesario cuando tu aplicación requiere ajustes explícitos de la conexión.