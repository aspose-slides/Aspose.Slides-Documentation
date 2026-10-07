---
title: Aspose.Slides Android számára Java-val
second_title: Aspose.Slides Android számára
type: docs
weight: 40
url: /hu/androidjava/
keywords:
- dokumentáció
- prezentáció feldolgozás
- prezentáció konvertálás
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Kezdje itt: adja hozzá az Aspose.Slides Androidhoz Java-val könyvtárat az alkalmazásához, hozza létre az első prezentációt, és találja meg az útmutatókat a gyakori feladatokhoz, az API referenciához és a támogatáshoz."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Android via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Az Aspose.Slides for Android via Java egy osztálykönyvtár PowerPoint és OpenDocument előadások létrehozásához, olvasásához, szerkesztéséhez és átalakításához Android alkalmazásokban, a Microsoft PowerPoint nélkül.

Betölti és menti a PPT, PPTX, PPS, POT és ODP formátumokat, beleértve a makróval ellátott és sablonváltozatokat, és exportál PDF, XPS, HTML, SVG, TIFF, Markdown és képek formátumba.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Get Started</b></p>
<hr>
<p>ELKEZDÉS</p>
<ul>
<li><a href="/slides/hu/androidjava/install-aspose-slides-for-android-via-java/">Telepítés</a></li>
<li><a href="/slides/hu/androidjava/create-presentation/">Hozza létre első előadását</a></li>
<li><a href="/slides/hu/androidjava/getting-started/">Első lépések útmutatója</a></li>
</ul>
<p>ÉRTÉKELÉS</p>
<ul>
<li><a href="/slides/hu/androidjava/supported-file-formats/">Támogatott fájlformátumok</a></li>
<li><a href="/slides/hu/androidjava/evaluate-aspose-slides/">Próba korlátai</a></li>
<li><a href="/slides/hu/androidjava/licensing/">Licencelés</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Build with Slides</b></p>
<hr>
<p>ÁLTALAN FELADATOK</p>
<ul>
<li><a href="/slides/hu/androidjava/open-presentation/">Előadás megnyitása</a></li>
<li><a href="/slides/hu/androidjava/save-presentation/">Előadás mentése</a></li>
<li><a href="/slides/hu/androidjava/convert-powerpoint-to-pdf/">PDF-be konvertálás</a></li>
<li><a href="/slides/hu/androidjava/convert-slide/">Dia renderelése képeként</a></li>
<li><a href="/slides/hu/androidjava/manage-text/">Szöveg és alakzatok szerkesztése</a></li>
</ul>
<p>SLIDE MUNKAÁRAMOK</p>
<ul>
<li><a href="/slides/hu/androidjava/powerpoint-charts/">Diagramok</a></li>
<li><a href="/slides/hu/androidjava/powerpoint-animation/">Animációk</a></li>
<li><a href="/slides/hu/androidjava/manage-media-files/">Hang és videó</a></li>
<li><a href="/slides/hu/androidjava/presentation-design/">Dia tervezés</a></li>
<li><a href="/slides/hu/androidjava/merge-presentation/">Előadások egyesítése</a></li>
</ul>
<p>PÉLDÁK</p>
<ul>
<li><a href="/slides/hu/androidjava/examples/">Példák diaelemek szerint</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference &amp; Support</b></p>
<hr>
<p>REFERENCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/androidjava/">API referencia</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/release-notes/">Kiadási jegyzetek</a></li>
<li><a href="/slides/hu/androidjava/known-issues/">Ismert problémák</a></li>
<li><a href="https://products.aspose.com/slides/android-java/">Termékoldal</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/">Letöltés</a></li>
</ul>
<p>TÁMOGATÁS</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Ingyenes támogatási fórum</a></li>
<li><a href="https://helpdesk.aspose.com/">Fizetett támogatási helpdesk</a></li>
</ul>
</div>
</div>

------

## **Az első előadás**

A könyvtár az Aspose Maven tárolójából származik. Az új Android Studio projektek már tartalmaznak egy `dependencyResolutionManagement` blokkot a *settings.gradle.kts* fájlban. Adja hozzá az alább látható `maven` sort a `repositories` blokkba, ahelyett, hogy egy második blokkot illesztene be:

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

[Telepítés](/slides/hu/androidjava/install-aspose-slides-for-android-via-java/) kiterjed a Groovy build szkriptekre, a kézi JAR fájlra, és arra, hogyan válasszon verziót. Az első előadás kódja a [Előadások létrehozása](/slides/hu/androidjava/create-presentation/): hozzáad egy szövegmezőt egy diára, és elmenti az előadást az alkalmazás tárolójába. Ez a minta le lett fordítva és APK-ba építve; még nem futtatott eszközön. Licenc nélkül a mentett előadások értékelési vízjelet tartalmaznak — lásd a [Licencelés](/slides/hu/androidjava/licensing/).