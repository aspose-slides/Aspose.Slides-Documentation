---
title: Multithreading en Aspose.Slides
type: docs
weight: 310
url: /androidjava/multithreading/
keywords:
- PowerPoint
- presentación
- multihilo
- trabajo en paralelo
- convertir diapositivas
- diapositivas a imágenes
- Android
- Java
- Aspose.Slides para Android a través de Java
---

## **Introducción**

Mientras que el trabajo en paralelo con presentaciones es posible (además de analizar/cargar/clonar) y todo va bien (la mayoría de las veces), hay una pequeña posibilidad de que obtenga resultados incorrectos cuando utiliza la biblioteca en múltiples hilos.

Recomendamos encarecidamente que **no** use una sola instancia de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) en un entorno de multihilo, ya que podría resultar en errores o fallos impredecibles que no son fácilmente detectables.

No es **seguro** cargar, guardar y/o clonar una instancia de una clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) en múltiples hilos. Tales operaciones **no** son compatibles. Si necesita realizar estas tareas, debe paralelizar las operaciones utilizando varios procesos de un solo hilo, y cada uno de estos procesos debe usar su propia instancia de presentación.

## **Convertir Diapositivas de Presentación a Imágenes en Paralelo**

Supongamos que queremos convertir todas las diapositivas de una presentación de PowerPoint a imágenes PNG en paralelo. Dado que no es seguro usar una sola instancia de `Presentation` en múltiples hilos, dividimos las diapositivas de la presentación en presentaciones separadas y convertimos las diapositivas a imágenes en paralelo, utilizando cada presentación en un hilo separado. El siguiente ejemplo de código muestra cómo hacer esto.

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

// Esperar a que todas las tareas se completen.
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```