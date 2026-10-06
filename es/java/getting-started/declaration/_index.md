---
title: Requisitos del Security Manager
type: docs
weight: 190
url: /es/java/declaration/
keywords:
- Gestor de Seguridad
- política de seguridad
- AllPermission
- permisos
- sandbox
- JDK 24
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Qué permisos del Security Manager necesita Aspose.Slides para Java y el código que lo llama en Java 23 y anteriores, y por qué no hay nada que configurar en Java 24 y posteriores."
---
## **Visión general**

El Security Manager de Java limita lo que el código puede hacer según una política de seguridad. Java 17 lo marcó como obsoleto para su eliminación ([JEP 411](https://openjdk.org/jeps/411)), y Java 24 lo desactivó permanentemente ([JEP 486](https://openjdk.org/jeps/486)). Este artículo explica qué necesita Aspose.Slides para Java cuando una aplicación sigue ejecutándose con un Security Manager. Si su aplicación no habilita uno, que es lo predeterminado, no hay nada que configurar.

## **Java 23 y versiones anteriores**

Cuando un Security Manager está habilitado, la política de seguridad debe conceder estos permisos al archivo JAR de Aspose.Slides y al código de la aplicación que lo llama:

- `java.util.PropertyPermission "*", "read"`: Aspose.Slides lee propiedades del sistema.
- `java.io.FilePermission "<<ALL FILES>>", "read"`: Aspose.Slides lee archivos de fuentes y otros archivos.
- `java.io.FilePermission "<<ALL FILES>>", "execute"`: Aspose.Slides inicia programas del sistema operativo, por ejemplo `reg` en Windows y `fc-match` en Linux.
- `java.io.FilePermission` con la acción `write` para las carpetas donde su aplicación guarda archivos.

Conceder los permisos solo al archivo JAR no es suficiente: el código que llama a Aspose.Slides también los necesita. Conceder `java.security.AllPermission` a ambos también funciona.

Sin el permiso para leer propiedades del sistema o para iniciar programas, Aspose.Slides falla en el primer uso: crear un objeto [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) lanza un `ExceptionInInitializerError`. Sin acceso de lectura a los archivos de fuentes, guardar una presentación como PDF falla con el error "Cannot find any fonts installed on the system".

## **Java 24 y posteriores**

El Security Manager no puede habilitarse en Java 24 y versiones posteriores, por lo que no hay permisos que conceder. Aspose.Slides se ejecuta con los permisos de la cuenta que ejecuta su aplicación. Para restringir a qué puede acceder una aplicación, el proyecto OpenJDK recomienda tecnologías externas al JDK, como contenedores, hipervisores y características de sandbox del sistema operativo. Véase [JEP 486](https://openjdk.org/jeps/486).

## **Preguntas frecuentes**

**¿Puedo usar Aspose.Slides en un entorno que ejecute aplicaciones bajo una política restrictiva del Security Manager?**

Solo si la política concede los permisos enumerados arriba tanto a Aspose.Slides como al código que lo llama. Incluyen la lectura de todos los archivos y el inicio de cualquier programa.