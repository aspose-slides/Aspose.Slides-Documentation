---
title: Multithreading dans Aspose.Slides pour Android via Java
linktitle: Multithreading
type: docs
weight: 310
url: /fr/androidjava/multithreading/
keywords:
- multithreading
- plusieurs threads
- travail parallèle
- conversion de diapositives
- diapositives en images
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Le multithreading d'Aspose.Slides pour Android via Java améliore le traitement de PowerPoint et d'OpenDocument. Découvrez les meilleures pratiques pour des flux de travail de présentation efficaces."
---

## **Introduction**

Bien que le travail parallèle avec les présentations soit possible (en dehors de l'analyse, du chargement ou du clonage) et que tout se passe bien (la plupart du temps), il existe une petite probabilité d’obtenir des résultats incorrects lorsque vous utilisez la bibliothèque dans plusieurs threads.

Nous vous recommandons fortement de **ne pas** utiliser une seule instance de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) dans un environnement multithread, car cela pourrait entraîner des erreurs ou des échecs imprévisibles qui sont difficiles à détecter.

Il n’est **pas** sûr de charger, enregistrer ou cloner une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) dans plusieurs threads. Ces opérations ne sont **pas** prises en charge. Si vous devez effectuer de telles tâches, vous devez paralléliser les opérations en utilisant plusieurs processus monothread, chaque processus devant utiliser sa propre instance de présentation.

## **Convertir les diapositives de la présentation en images en parallèle**

Imaginons que nous voulions convertir toutes les diapositives d’une présentation PowerPoint en images PNG en parallèle. Comme il est dangereux d’utiliser une seule instance `Presentation` dans plusieurs threads, nous divisons les diapositives de la présentation en présentations distinctes et convertissons les diapositives en images en parallèle, chaque présentation étant utilisée dans un thread séparé. L’exemple de code suivant montre comment procéder.
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
	// Extraire la diapositive i dans une présentation distincte.
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// Convertir la diapositive en image dans une tâche séparée.
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


## **FAQ**

**Dois‑je appeler la configuration de licence dans chaque thread ?**

Non. Il suffit de le faire une fois par processus ou domaine d’application avant le démarrage des threads. Si la [configuration de licence](/slides/fr/androidjava/licensing/) peut être invoquée simultanément (par exemple lors d’une initialisation paresseuse), synchronisez cet appel car la méthode de configuration de licence elle‑même n’est pas thread‑safe.

**Puis‑je transmettre des objets `Presentation` ou `Slide` entre les threads ?**

Il n’est pas recommandé de transmettre des objets de présentation « vivants » entre les threads : utilisez des instances indépendantes par thread ou créez à l’avance des présentations/conteneurs de diapositives séparés pour chaque thread. Cette approche suit la recommandation générale de ne pas partager une seule instance de présentation entre les threads.

**Est‑ce sûr de paralléliser l’exportation vers différents formats (PDF, HTML, images) à condition que chaque thread possède sa propre instance `Presentation` ?**

Oui. Avec des instances indépendantes et des chemins de sortie séparés, ces tâches se parallélisent généralement correctement ; évitez tout partage d’objets de présentation ou de flux d’E/S.

**Que faire avec les paramètres de police globaux (dossiers, substitutions) en multithreading ?**

Initialisez tous les [paramètres de police](/slides/fr/androidjava/powerpoint-fonts/) globaux avant de démarrer les threads et ne les modifiez pas pendant le travail parallèle. Cela élimine les conditions de concurrence lors de l’accès aux ressources de police partagées.