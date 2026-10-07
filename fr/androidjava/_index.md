---
title: Aspose.Slides pour Android via Java
second_title: Aspose.Slides pour Android
type: docs
weight: 40
url: /fr/androidjava/
keywords:
- documentation
- traitement de présentation
- conversion de présentation
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Commencez ici: ajoutez Aspose.Slides pour Android via Java à votre application, créez une première présentation et trouvez les guides pour les tâches courantes, la référence API et le support."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides pour Android via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides pour Android via Java est une bibliothèque de classes permettant de créer, lire, modifier et convertir des présentations PowerPoint et OpenDocument dans des applications Android, sans Microsoft PowerPoint.

Elle charge et enregistre les formats PPT, PPTX, PPS, POT et ODP, y compris les variantes macro‑enabled et templates, et exporte vers PDF, XPS, HTML, SVG, TIFF, Markdown et images.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Commencer</b></p>
<hr>
<p>DÉMARRAGE</p>
<ul>
<li><a href="/slides/fr/androidjava/install-aspose-slides-for-android-via-java/">Installation</a></li>
<li><a href="/slides/fr/androidjava/create-presentation/">Créer votre première présentation</a></li>
<li><a href="/slides/fr/androidjava/getting-started/">Guide de démarrage</a></li>
</ul>
<p>ÉVALUER</p>
<ul>
<li><a href="/slides/fr/androidjava/supported-file-formats/">Formats de fichiers pris en charge</a></li>
<li><a href="/slides/fr/androidjava/evaluate-aspose-slides/">Limitations de l'essai</a></li>
<li><a href="/slides/fr/androidjava/licensing/">Licence</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Construire avec Slides</b></p>
<hr>
<p>TÂCHES COURANTES</p>
<ul>
<li><a href="/slides/fr/androidjava/open-presentation/">Ouvrir une présentation</a></li>
<li><a href="/slides/fr/androidjava/save-presentation/">Enregistrer une présentation</a></li>
<li><a href="/slides/fr/androidjava/convert-powerpoint-to-pdf/">Convertir en PDF</a></li>
<li><a href="/slides/fr/androidjava/convert-slide/">Rendre les diapositives en images</a></li>
<li><a href="/slides/fr/androidjava/manage-text/">Modifier le texte et les formes</a></li>
</ul>
<p>FLUX DE TRAVAIL SLIDES</p>
<ul>
<li><a href="/slides/fr/androidjava/powerpoint-charts/">Graphiques</a></li>
<li><a href="/slides/fr/androidjava/powerpoint-animation/">Animations</a></li>
<li><a href="/slides/fr/androidjava/manage-media-files/">Audio et vidéo</a></li>
<li><a href="/slides/fr/androidjava/presentation-design/">Conception de diapositives</a></li>
<li><a href="/slides/fr/androidjava/merge-presentation/">Fusionner des présentations</a></li>
</ul>
<p>EXEMPLES</p>
<ul>
<li><a href="/slides/fr/androidjava/examples/">Exemples par élément de diapositive</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Référence &amp; Support</b></p>
<hr>
<p>RÉFÉRENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/androidjava/">Référence API</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/release-notes/">Notes de version</a></li>
<li><a href="/slides/fr/androidjava/known-issues/">Problèmes connus</a></li>
<li><a href="https://products.aspose.com/slides/android-java/">Page produit</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/">Télécharger</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Forum de support gratuit</a></li>
<li><a href="https://helpdesk.aspose.com/">Assistance payante</a></li>
</ul>
</div>
</div>

------

## **Votre première présentation**

La bibliothèque provient du dépôt Maven d'Aspose. Les nouveaux projets Android Studio possèdent déjà un bloc `dependencyResolutionManagement` dans *settings.gradle.kts*. Ajoutez la ligne `maven` affichée ci‑dessous au bloc `repositories` à l'intérieur, au lieu de coller un second bloc :

```kotlin
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = uri("https://releases.aspose.com/java/repo/") }
    }
}
```

Puis ajoutez la bibliothèque à *app/build.gradle.kts* et synchronisez le projet :

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

[Installation](/slides/fr/androidjava/install-aspose-slides-for-android-via-java/) couvre les scripts de construction Groovy, le fichier JAR manuel et la façon de choisir une version. Le code de votre première présentation se trouve sur [Créer des présentations](/slides/fr/androidjava/create-presentation/) : il ajoute une zone de texte à une diapositive et enregistre la présentation dans le stockage de votre application. Cet exemple a été compilé et intégré dans un APK ; il n’a pas été exécuté sur un appareil. Sans licence, les présentations enregistrées portent un filigrane d’évaluation — voir [Licence](/slides/fr/androidjava/licensing/).