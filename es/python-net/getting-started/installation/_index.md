---
title: Instalación
type: docs
weight: 70
url: /es/python-net/installation/
keywords:
- descargar Aspose.Slides
- instalar Aspose.Slides
- usar Aspose.Slides
- instalación de Aspose.Slides
- pip
- PyPI
- Windows
- Linux
- macOS
- Python
description: "Instala Aspose.Slides for Python via .NET desde PyPI con pip en Windows, Linux y macOS, e instala las bibliotecas nativas que Linux y macOS necesitan."
---
## **Descripción general**

Este artículo explica cómo instalar Aspose.Slides for Python via .NET en Windows, Linux y macOS. El paquete se publica en [PyPI](https://pypi.org/project/aspose.slides/) y se instala con pip. Incluye el tiempo de ejecución .NET que utiliza, por lo que no es necesario instalar .NET. En Linux y macOS, ese tiempo de ejecución necesita bibliotecas nativas que el sistema operativo puede no incluir; las secciones siguientes las nombran.

Aspose.Slides for Python via .NET admite Python 3.5 a 3.14. PyPI proporciona paquetes para Windows (32 bits y 64 bits), Linux (x86_64 y ARM64) y macOS (Intel y Apple silicon).

## **Windows**

En Windows, instala el paquete con pip. No se requieren otras bibliotecas.

```bash
pip install aspose.slides
```

## **Linux**

En Linux, el tiempo de ejecución .NET incluido en el paquete necesita dos bibliotecas:

- **libgdiplus**, una implementación de la API gráfica Windows GDI+. Sin ella, al guardar una presentación se produce el error `The type initializer for 'Gdip' threw an exception`.
- **ICU** (International Components for Unicode). Sin ella, el proceso de Python termina en la primera llamada a Aspose.Slides con el mensaje `Couldn't find a valid ICU package installed on the system`.

En Debian y Ubuntu, instala ambas con apt:

```bash
sudo apt-get update && sudo apt-get install -y libgdiplus libicu76
```

El nombre del paquete ICU contiene su versión: `libicu76` es el paquete para Debian 13. En Debian 12, instala `libicu72` y en Ubuntu 24.04, `libicu74`. Para encontrar el nombre en tu sistema, ejecuta:

```bash
apt-cache search --names-only '^libicu[0-9]+$'
```

Luego instala el paquete en un entorno virtual. En las versiones actuales de Debian y Ubuntu, el Python del sistema no permite `pip install` fuera de un entorno virtual y se detiene con el error `externally-managed-environment`.

```bash
sudo apt-get install -y python3-venv
python3 -m venv .venv
. .venv/bin/activate
pip install aspose.slides
```

Ejecuta tus scripts con el mismo entorno virtual activado. Si utilizas un Python que tu distribución no gestiona, como el incluido en las imágenes oficiales `python` de Docker, también puedes ejecutar `pip install aspose.slides` sin un entorno virtual.

Las fuentes usadas en tus presentaciones, o sustitutos adecuados, deben estar instaladas en el sistema para que el texto se renderice correctamente al convertir diapositivas a PDF o imágenes.

## **macOS**

No hemos verificado la instalación en macOS. En macOS, Aspose.Slides necesita los siguientes prerrequisitos:

- **Python con bibliotecas compartidas**, es decir, Python compilado con la opción de configuración `--enable-shared`. Si instalas Python con [pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos), establece la variable de entorno `PYTHON_CONFIGURE_OPTS` a `--enable-shared` cuando instales una versión de Python.
- **La biblioteca libpython en un directorio de bibliotecas del sistema**. Un Python instalado con pyenv mantiene su biblioteca libpython, como *libpython3.9.dylib*, bajo *~/.pyenv/versions*; crea un enlace simbólico a ella en */usr/local/lib*.
- **libgdiplus**, una implementación de la API gráfica Windows GDI+. Homebrew la ofrece como el paquete `mono-libgdiplus`.

Luego instala el paquete con pip.

## **Comprobar la instalación**

Para comprobar la instalación, guarda el primer ejemplo en [Create Presentations](/slides/es/python-net/create-presentation/) como *hello.py* y ejecuta `python hello.py`. Se guardará *new_presentation.pptx* en la carpeta actual.

## **Actualización**

Para actualizar una instalación existente a la última versión, ejecuta este comando en el entorno donde instalaste el paquete:

```bash
pip install --upgrade aspose.slides
```

## **Preguntas frecuentes**

**¿Puedo instalar Aspose.Slides en un entorno virtual?**

Sí. Puedes instalarlo en cualquier entorno virtual de Python con pip. Las bibliotecas nativas que Linux y macOS requieren se instalan en el sistema, no en el entorno virtual.

**¿Puedo usar Aspose.Slides en contenedores Docker?**

Sí. La imagen debe incluir las mismas bibliotecas nativas que un sistema Linux — libgdiplus e ICU — y las fuentes que usan tus presentaciones.

**¿Existe una versión gratuita o limitación de prueba?**

Sí. Sin una licencia, Aspose.Slides se ejecuta en modo de evaluación: añade una marca de agua de evaluación a cada diapositiva que guardas y trunca el texto leído de las presentaciones. Para eliminar estas limitaciones, aplica una [license](/slides/es/python-net/licensing/).