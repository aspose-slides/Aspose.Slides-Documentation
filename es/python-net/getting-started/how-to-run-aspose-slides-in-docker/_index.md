---
title: Cómo ejecutar Aspose.Slides en Docker
linktitle: Aspose.Slides en Docker
type: docs
weight: 150
url: /es/python-net/how-to-run-aspose-slides-in-docker/
keywords:
- Aspose.Slides en Docker
- contenedor Docker
- Dockerfile
- Linux
- libgdiplus
- ICU
- OpenSSL
- fuentes
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Ejecute Aspose.Slides for Python via .NET en Docker: un Dockerfile funcional, las librerías nativas que necesita el paquete, la configuración de fuentes y la licencia dentro de un contenedor."
---
## **Visión general**

Aspose.Slides for Python via .NET se ejecuta en contenedores Linux, pero el paquete es un contenedor de Python alrededor de un runtime .NET Core 3.1 incluido. Ese runtime necesita tres bibliotecas nativas que las imágenes Python slim no incluyen, y es exigente con sus versiones. Este artículo proporciona un Dockerfile que funciona, explica por qué cada dependencia está presente y muestra cómo añadir fuentes y una licencia.

## **Un Dockerfile funcional**

```dockerfile
FROM python:3.11-slim-bullseye

RUN apt-get update && apt-get install -y --no-install-recommends \
        libgdiplus \
        libicu67 \
        libfontconfig1 \
        fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*

RUN pip install --no-cache-dir aspose.slides

WORKDIR /app
COPY app.py .
CMD ["python", "app.py"]
```

`app.py`:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    shape.text_frame.text = "Created inside a Docker container"
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)
```

Compilar y ejecutar:

```bash
docker build -t aspose-slides-python .
docker run --rm aspose-slides-python
```

## **Por qué la imagen base es Debian 11**

La rueda `aspose.slides` incluye un runtime **.NET Core 3.1**, y ese runtime es anterior a las versiones de biblioteca que incluyen las versiones actuales de Debian. En Debian 12 y 13 el contenedor se construye correctamente pero falla en la primera llamada a `Presentation()`:

```
Process terminated. Couldn't find a valid ICU package installed on the system.
```

El mensaje es engañoso — ICU *está* instalado en esas imágenes, pero es ICU 72 o 76, y .NET Core 3.1 solo reconoce versiones mayores más antiguas. Debian 12 además incluye OpenSSL 3, lo que produce un segundo error:

```
No usable version of libssl was found
```

`python:3.11-slim-bullseye` es Debian 11, que proporciona ambas versiones que el runtime incluido espera:

| Paquete | Versión en Debian 11 | Por qué es necesario |
|---|---|---|
| `libgdiplus` | 6.0.4 | Implementación GDI+ utilizada para renderizar formas, texto e imágenes |
| `libicu67` | 67.1 | Datos de globalización. Las versiones mayores más recientes no son reconocidas por .NET Core 3.1 |
| `libssl1.1` | 1.1.1w | Criptografía. Preinstalado en Debian 11; ausente en Debian 12+ |
| `libfontconfig1` | — | Descubrimiento de fuentes |

`libssl1.1` ya está presente en la imagen base, por lo que no es necesario incluirlo en `apt-get install`.

Si debe utilizar una imagen base más reciente, establezca `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1` para eludir el requisito de ICU. Esto desactiva el formato dependiente de la cultura y **no** resuelve el problema de OpenSSL, por lo que Debian 11 sigue siendo la opción más sencilla.

## **Fuentes**

Las imágenes slim no contienen fuentes en absoluto. Sin al menos una fuente instalada, el texto se muestra como cajas vacías en la salida PDF, de imagen y HTML. `fonts-dejavu-core` es un pequeño punto de partida de propósito general.

Para que la presentación tenga la apariencia prevista, copie las fuentes que utiliza dentro de la imagen y apunte Aspose.Slides a ellas:

```dockerfile
COPY fonts/ /usr/share/fonts/truetype/custom/
RUN fc-cache -f
```

```py
import aspose.slides as slides

slides.FontsLoader.load_external_fonts(["/usr/share/fonts/truetype/custom/"])
```

## **Licencias dentro de un contenedor**

No incorpore el archivo de licencia en la imagen — cualquier persona que descargue la imagen obtendrá la licencia. Montela en tiempo de ejecución en su lugar:

```bash
docker run --rm -v /path/on/host:/license aspose-slides-python
```

```py
import aspose.slides as slides

license = slides.License()
license.set_license("/license/Aspose.Slides.Python.NET.lic")
```

Sin una licencia la biblioteca funciona en modo de evaluación, lo que añade una marca de agua y limita el número de diapositivas procesadas. Consulte [Licencias](/slides/es/python-net/licensing/) para más detalles.

## **Memoria**

Renderizar a PDF o imágenes consume más memoria que leer un archivo. Los contenedores con límites de memoria estrictos pueden ser finalizados por el OOM killer a mitad de una conversión, lo que generalmente se manifiesta como la desaparición del proceso sin una traza de error de Python. Si ocurre, aumente el límite de memoria del contenedor antes de investigar el código.