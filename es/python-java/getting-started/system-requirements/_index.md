---
title: Requisitos del sistema
type: docs
weight: 60
url: /es/python-java/system-requirements/
keywords:
- requisitos del sistema
- Python
- Java
- JPype
- Windows
- Linux
- macOS
- Aspose.Slides
description: "Compruebe los requisitos de sistema operativo, Python, Java y JPype para ejecutar Aspose.Slides for Python via Java en Windows, Linux y macOS."
---
## **Descripción general**

Aspose.Slides for Python via Java crea, modifica, convierte y renderiza presentaciones sin necesidad de tener Microsoft PowerPoint instalado. Utiliza JPype para acceder a la biblioteca Java desde Python, por lo que el entorno debe admitir Python, Java y JPype simultáneamente.

## **Sistemas operativos admitidos**

El [paquete Aspose.Slides](https://pypi.org/project/aspose-slides-java/) admite las siguientes familias de sistemas operativos:

- Windows
- Linux
- macOS

Elija una versión del sistema operativo compatible con las versiones de Python, Java y JPype que haya seleccionado. La disponibilidad de Java por sí sola no garantiza la compatibilidad con el paquete de Python y su puente.

## **Requisitos de Python, Java y JPype**

| Componente | Requisito |
| --- | --- |
| Python | El paquete Aspose.Slides declara compatibilidad con Python 3.7 a 3.14. La versión de JPype seleccionada debe soportar la misma versión de Python; por ejemplo, [JPype1 1.7.1](https://pypi.org/project/jpype1/1.7.1/) requiere Python 3.8 o posterior. |
| Java | Instale un runtime o JDK de Java compatible con la versión de JPype seleccionada. Los [requisitos previos de JPype actuales](https://jpype.readthedocs.io/en/latest/userguide.html#prerequisites) especifican Java 11 o posterior. Java 8 no puede ejecutar JPype1 1.7.1. |
| JPype | Instale el paquete JPype1 para su intérprete de Python, sistema operativo y arquitectura de CPU. |
| Arquitectura de CPU | Python y la Máquina Virtual Java (JVM) deben usar arquitecturas coincidentes. Por ejemplo, un intérprete de Python de 64 bits requiere una JVM de 64 bits compatible. |

En Apple Silicon, Python y Java deben usar ambos ARM64 o ambos x64. Una JVM que se ejecute de forma independiente aún puede fallar al cargarse mediante JPype si su arquitectura difiere de la de Python.

Para un entorno nuevo, Python 3.12, JDK 17 y JPype1 1.7.1 son un punto de partida adecuado. Esta combinación se verificó con Aspose.Slides for Python via Java 26.6.0 en Windows. Otras combinaciones deben satisfacer los requisitos de los tres componentes.

Para la configuración del entorno y un ejemplo de verificación funcional, consulte [Instalación](/slides/es/python-java/installation/).

## **Dependencias adicionales**

Una rueda precompilada compatible de JPype no requiere un compilador de C++. Si JPype debe compilarse desde el código fuente, instale un compilador de C++ compatible y los archivos de desarrollo de Python requeridos por su plataforma. Consulte las [instrucciones de instalación de JPype](https://jpype.readthedocs.io/en/latest/install.html) para los requisitos de compilación y la solución de problemas.

## **Preguntas frecuentes**

**¿Necesito tener Microsoft PowerPoint instalado?**

No. Aspose.Slides procesa presentaciones de forma independiente de PowerPoint. Python, Java y JPype siguen siendo necesarios.

**¿Puedo usar Python 3.7 con cualquier versión de JPype?**

No. Aunque el paquete Aspose.Slides declara compatibilidad con Python 3.7, JPype1 1.7.1 requiere Python 3.8 o posterior. Elija versiones cuyas exigencias se superpongan.

**¿Puedo combinar Python de 32 bits con Java de 64 bits?**

No. JPype carga la JVM dentro del proceso de Python, por lo que Python y Java deben tener arquitecturas coincidentes. El mismo requisito se aplica a ARM64 y x64 en macOS.