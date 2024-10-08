---
title: Multithreading dans Aspose.Slides
type: docs
weight: 310
url: /fr/androidjava/multithreading/
keywords:
- PowerPoint
- présentation
- multithreading
- travail parallèle
- convertir des diapositives
- diapositives en images
- Android
- Java
- Aspose.Slides pour Android via Java
---

## **Introduction**

Bien que le travail parallèle avec des présentations soit possible (en plus de l'analyse/chargement/clonage) et que tout se passe bien (la plupart du temps), il y a un petit risque que vous obteniez des résultats incorrects lorsque vous utilisez la bibliothèque dans plusieurs threads.

Nous recommandons fortement de **ne pas** utiliser une seule instance de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) dans un environnement multi-threading car cela pourrait entraîner des erreurs ou des pannes imprévisibles qui ne sont pas facilement détectées.

Il **n'est pas** sûr de charger, enregistrer et/ou cloner une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) dans plusieurs threads. De telles opérations **ne sont pas** prises en charge. Si vous devez effectuer de telles tâches, vous devez paralléliser les opérations en utilisant plusieurs processus à thread unique — et chacun de ces processus doit utiliser sa propre instance de présentation.

## **Convertir les diapositives de présentation en images en parallèle**

Disons que nous voulons convertir toutes les diapositives d'une présentation PowerPoint en images PNG en parallèle. Puisqu'il est dangereux d'utiliser une seule instance de `Presentation` dans plusieurs threads, nous divisons les diapositives de la présentation en présentations distinctes et convertissons les diapositives en images en parallèle, en utilisant chaque présentation dans un thread séparé. L'exemple de code suivant montre comment faire cela.

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
	// Extraire la diapositive i dans une présentation séparée.
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// Convertir la diapositive en une image dans une tâche séparée.
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

// Attendre que toutes les tâches soient terminées.
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```