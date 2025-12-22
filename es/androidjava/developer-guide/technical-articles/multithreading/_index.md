---
title: Multihilo en Aspose.Slides para Android mediante Java
linktitle: Multihilo
type: docs
weight: 310
url: /es/androidjava/multithreading/
keywords:
- multihilo
- múltiples hilos
- trabajo paralelo
- convertir diapositivas
- diapositivas a imágenes
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "El multihilo de Aspose.Slides para Android mediante Java mejora el procesamiento de PowerPoint y OpenDocument. Descubra las mejores prácticas para flujos de trabajo de presentaciones eficientes."
---

## **Introducción**

Aunque el trabajo paralelo con presentaciones es posible (además del análisis/carga/clonado) y todo funciona bien (la mayoría de las veces), existe una pequeña posibilidad de que obtengas resultados incorrectos al usar la biblioteca en varios hilos.

Recomendamos encarecidamente que **no** utilices una única instancia de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) en un entorno de multihilos porque podría resultar en errores o fallas impredecibles que no se detectan fácilmente.

No es **seguro** cargar, guardar y/o clonar una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) en varios hilos. Tales operaciones **no** son compatibles. Si necesitas realizar esas tareas, debes paralelizar las operaciones usando varios procesos de un solo hilo, y cada uno de estos procesos debe usar su propia instancia de presentación.

## **Convertir diapositivas de presentación a imágenes en paralelo**

Supongamos que queremos convertir todas las diapositivas de una presentación de PowerPoint a imágenes PNG en paralelo. Dado que no es seguro usar una única instancia de `Presentation` en varios hilos, dividimos las diapositivas de la presentación en presentaciones separadas y convertimos las diapositivas a imágenes en paralelo, usando cada presentación en un hilo distinto. El siguiente ejemplo de código muestra cómo hacerlo.
```java
String inputFilePath = "sample.pptx";
final String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
SizeF slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<Thread> threads = new ArrayList<Thread>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
	// Extraer la diapositiva i en una presentación separada.
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// Convertir la diapositiva a una imagen en una tarea separada.
	final int slideNumber = slideIndex + 1;
	threads.add(new Thread(new Runnable() {
		@Override
		public void run() {
			IImage image = null;
			try {
				ISlide slide = slidePresentation.getSlides().get_Item(0);

				image = slide.getImage(imageScale, imageScale);
				String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
				image.save(imageFilePath, ImageFormat.Png);
			} finally {
				if (image != null) image.dispose();
				slidePresentation.dispose();
			}
		}
	}));
}

// Esperar a que todas las tareas terminen.
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```


## **Preguntas frecuentes**

**¿Necesito llamar a la configuración de licencia en cada hilo?**

No. Es suficiente hacerlo una vez por proceso o dominio de aplicación antes de que los hilos comiencen. Si la [configuración de licencia](/slides/es/androidjava/licensing/) pudiera invocarse simultáneamente (por ejemplo, durante la inicialización perezosa), sincroniza esa llamada porque el método de configuración de licencia en sí no es seguro para hilos.

**¿Puedo pasar objetos `Presentation` o `Slide` entre hilos?**

Pasar objetos de presentación "en vivo" entre hilos no se recomienda: utiliza instancias independientes por hilo o precrea presentaciones/contendedores de diapositivas separados para cada hilo. Este enfoque sigue la recomendación general de no compartir una única instancia de presentación entre hilos.

**¿Es seguro paralelizar la exportación a diferentes formatos (PDF, HTML, imágenes) siempre que cada hilo tenga su propia instancia de `Presentation`?**

Sí. Con instancias independientes y rutas de salida separadas, esas tareas suelen paralelizarse correctamente; evita cualquier objeto de presentación compartido y cualquier flujo de E/S compartido.

**¿Qué debo hacer con la configuración global de fuentes (carpetas, sustituciones) en multihilos?**

Inicializa toda la [configuración de fuentes](/slides/es/androidjava/powerpoint-fonts/) global antes de iniciar los hilos y no la modifiques durante el trabajo paralelo. Esto elimina condiciones de carrera al acceder a recursos de fuentes compartidos.