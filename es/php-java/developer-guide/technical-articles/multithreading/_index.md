---
title: Multihilo en Aspose.Slides para PHP mediante Java
linktitle: Multihilo
type: docs
weight: 310
url: /es/php-java/multithreading/
keywords:
- multihilo
- múltiples hilos
- trabajo paralelo
- convertir diapositivas
- diapositivas a imágenes
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "El multihilo de Aspose.Slides para PHP mediante Java mejora el procesamiento de PowerPoint y OpenDocument. Descubra las mejores prácticas para flujos de trabajo de presentaciones eficientes."
---

## **Introducción**

Aunque el trabajo paralelo con presentaciones es posible (además del parsing/loading/cloning) y la mayoría de las veces todo funciona bien, existe una pequeña probabilidad de que obtengas resultados incorrectos al usar la biblioteca en varios hilos.

Recomendamos encarecidamente que **no** uses una única instancia de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) en un entorno multihilo porque podría dar lugar a errores o fallos impredecibles que no se detectan fácilmente.

No es **seguro** cargar, guardar y/o clonar una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) en varios hilos. Estas operaciones **no** son compatibles. Si necesitas realizar esas tareas, debes paralelizar las operaciones usando varios procesos monohilo, y cada uno de estos procesos debe usar su propia instancia de [Presentation].

No garantizamos el multihilo en PHP al usar extensiones. Si las utilizas, hazlo bajo tu propio riesgo.

## **Preguntas frecuentes**

**¿Necesito llamar a la configuración de licencia en cada hilo?**

No. Basta hacerlo una vez por proceso o dominio de aplicación antes de que inicien los hilos. Si la [license setup](/slides/es/php-java/licensing/) puede invocarse simultáneamente (por ejemplo, durante la inicialización perezosa), sincroniza esa llamada porque el método de configuración de licencia no es seguro para hilos.

**¿Puedo pasar objetos `Presentation` o `Slide` entre hilos?**

Pasar objetos de presentación “en vivo” entre hilos no se recomienda: utiliza instancias independientes por hilo o crea previamente presentaciones/contendedores de diapositivas separados para cada hilo. Este enfoque sigue la recomendación general de no compartir una única instancia de [Presentation] entre hilos.

**¿Es seguro paralelizar la exportación a diferentes formatos (PDF, HTML, imágenes) siempre que cada hilo tenga su propia instancia `Presentation`?**

Sí. Con instancias independientes y rutas de salida separadas, esas tareas suelen paralelizarse correctamente; evita cualquier objeto de presentación compartido y cualquier flujo de E/S compartido.

**¿Qué debo hacer con la configuración global de fuentes (carpetas, sustituciones) en un entorno multihilo?**

Inicializa toda la configuración global de [font settings](/slides/es/php-java/powerpoint-fonts/) antes de iniciar los hilos y no la modifiques durante el trabajo paralelo. Esto elimina las condiciones de carrera al acceder a recursos de fuentes compartidos.