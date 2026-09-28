---
title: Aspose.Slides Androidra Java segítségével
second_title: Aspose.Slides Androidra
type: docs
weight: 40
url: /hu/androidjava/
keywords:
- dokumentáció
- bemutatófeldolgozás
- bemutatókonverzió
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Kezdje itt: adja hozzá az Aspose.Slides for Android via Java könyvtárat az alkalmazásához, hozzon létre egy első bemutatót, és találja meg az általános feladatok útmutatóit, az API-referenciát és a támogatást."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Android via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Az Aspose.Slides for Android via Java egy osztálykönyvtár a PowerPoint és OpenDocument bemutatók létrehozásához, olvasásához, szerkesztéséhez és konvertálásához Android-alkalmazásokban, a Microsoft PowerPoint nélkül.

Betölti és menti a PPT, PPTX, PPS, POT és ODP formátumokat, beleértve a makróval rendelkező és sablonváltozatokat is, valamint exportál PDF, XPS, HTML, SVG, TIFF, Markdown és képek formátumba.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Első lépések</b></p>
<hr>
<p>ELKEZDÉS</p>
<ul>
<li><a href="/slides/hu/androidjava/install-aspose-slides-for-android-via-java/">Telepítés</a></li>
<li><a href="/slides/hu/androidjava/create-presentation/">Készítse el első bemutatóját</a></li>
<li><a href="/slides/hu/androidjava/getting-started/">Első lépések útmutató</a></li>
</ul>
<p>ÉRTÉKELÉS</p>
<ul>
<li><a href="/slides/hu/androidjava/supported-file-formats/">Támogatott fájlformátumok</a></li>
<li><a href="/slides/hu/androidjava/evaluate-aspose-slides/">Próbaidőkorlátok</a></li>
<li><a href="/slides/hu/androidjava/licensing/">Licencelés</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Készítés Slides-szel</b></p>
<hr>
<p>ÁLTALÁNOS FELADATOK</p>
<ul>
<li><a href="/slides/hu/androidjava/open-presentation/">Bemutató megnyitása</a></li>
<li><a href="/slides/hu/androidjava/save-presentation/">Bemutató mentése</a></li>
<li><a href="/slides/hu/androidjava/convert-powerpoint-to-pdf/">PDF-re konvertálás</a></li>
<li><a href="/slides/hu/androidjava/convert-slide/">Diaok képként megjelenítése</a></li>
<li><a href="/slides/hu/androidjava/manage-text/">Szöveg és alakzatok szerkesztése</a></li>
</ul>
<p>DIÁK MUNKAFOLYAMA</p>
<ul>
<li><a href="/slides/hu/androidjava/powerpoint-charts/">Diagramok</a></li>
<li><a href="/slides/hu/androidjava/powerpoint-animation/">Animációk</a></li>
<li><a href="/slides/hu/androidjava/manage-media-files/">Hang és videó</a></li>
<li><a href="/slides/hu/androidjava/presentation-design/">Dia tervezés</a></li>
<li><a href="/slides/hu/androidjava/merge-presentation/">Bemutatók egyesítése</a></li>
</ul>
<p>PÉLDÁK</p>
<ul>
<li><a href="/slides/hu/androidjava/examples/">Példák diaelemek szerint</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referenciák és támogatás</b></p>
<hr>
<p>REFERENCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/androidjava/">API referencia</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/release-notes/">Kiadási megjegyzések</a></li>
<li><a href="/slides/hu/androidjava/known-issues/">Ismert problémák</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/">Letöltés</a></li>
</ul>
<p>TÁMOGATÁS</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Ingyenes támogatási fórum</a></li>
<li><a href="https://helpdesk.aspose.com/">Fizetős támogatási helpdesk</a></li>
</ul>
</div>
</div>

------

## **Az első bemutatója**

A könyvtár az Aspose Maven tárolójából származik. Az új Android Studio projektek már tartalmazzák a `dependencyResolutionManagement` blokkot a *settings.gradle.kts* fájlban. Adja hozzá az alább látható `maven` sort a `repositories` blokkhoz, ahelyett, hogy egy második blokkot illesztene be:

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

Ezután adja hozzá a könyvtárat a *app/build.gradle.kts* fájlhoz, és szinkronizálja a projektet:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

[Telepítés](/slides/hu/androidjava/install-aspose-slides-for-android-via-java/) lefedi a Groovy build szkripteket, a manuális JAR fájlt, és azt, hogyan válasszon verziót. A kód az első bemutatóhoz a [Bemutatók létrehozása](/slides/hu/androidjava/create-presentation/) linken található: hozzáad egy szövegdobozt egy diához, és elmenti a bemutatót az alkalmazás tárhelyére. Ez a példa le lett fordítva és APK-ba építve; még nem futtatott eszközön. Licenc nélkül a mentett bemutatók értékelési vízjelet tartalmaznak — lásd [Licencelés](/slides/hu/androidjava/licensing/).