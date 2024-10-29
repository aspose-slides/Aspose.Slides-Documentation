---
title: Multihilos en Aspose.Slides
type: docs
weight: 310
url: /es/php-java/multithreading/
keywords:
- PowerPoint
- presentación
- multihilos
- trabajo en paralelo
- convertir diapositivas
- diapositivas a imágenes
- PHP
- Java
- Aspose.Slides para PHP a través de Java
---

## **Introducción**

Mientras que el trabajo en paralelo con presentaciones es posible (además de analizar/cargar/clonar) y todo va bien (la mayor parte del tiempo), existe una pequeña posibilidad de que obtengas resultados incorrectos cuando uses la biblioteca en múltiples hilos.

Recomendamos encarecidamente que **no** uses una única [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) instancia en un entorno de multihilos porque puede resultar en errores o fallos impredecibles que no son fáciles de detectar.

No es **seguro** cargar, guardar y/o clonar una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) en múltiples hilos. Tales operaciones **no** son compatibles. Si necesitas realizar tales tareas, debes paralelizar las operaciones utilizando varios procesos de un solo hilo, y cada uno de estos procesos debe usar su propia instancia de presentación.

No garantizamos multihilos en PHP al usar extensiones. Si las usas, hazlo bajo tu propio riesgo.