---
title: Aspose.Slides dla Androida w Java
second_title: Aspose.Slides dla Androida
type: docs
weight: 40
url: /pl/androidjava/
keywords:
- dokumentacja
- przetwarzanie prezentacji
- konwersja prezentacji
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Zacznij tutaj: dodaj Aspose.Slides for Android via Java do swojej aplikacji, utwórz pierwszą prezentację i znajdź przewodniki dotyczące typowych zadań, referencję API oraz wsparcie."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides dla Androida w Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Android via Java to biblioteka klas służąca do tworzenia, odczytywania, edytowania i konwertowania prezentacji PowerPoint oraz OpenDocument w aplikacjach Android, bez Microsoft PowerPoint.

Obsługuje wczytywanie i zapisywanie plików PPT, PPTX, PPS, POT oraz ODP, w tym wersje z makrami i szablony, oraz eksportuje do PDF, XPS, HTML, SVG, TIFF, Markdown i obrazów.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Rozpocznij</b></p>
<hr>
<p>ROZPOCZĘCIE</p>
<ul>
<li><a href="/slides/pl/androidjava/install-aspose-slides-for-android-via-java/">Instalacja</a></li>
<li><a href="/slides/pl/androidjava/create-presentation/">Utwórz swoją pierwszą prezentację</a></li>
<li><a href="/slides/pl/androidjava/getting-started/">Przewodnik wprowadzający</a></li>
</ul>
<p>EWALUACJA</p>
<ul>
<li><a href="/slides/pl/androidjava/supported-file-formats/">Obsługiwane formaty plików</a></li>
<li><a href="/slides/pl/androidjava/evaluate-aspose-slides/">Ograniczenia wersji próbnej</a></li>
<li><a href="/slides/pl/androidjava/licensing/">Licencjonowanie</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Tworzenie z Slides</b></p>
<hr>
<p>WSPÓLNE ZADANIA</p>
<ul>
<li><a href="/slides/pl/androidjava/open-presentation/">Otwórz prezentację</a></li>
<li><a href="/slides/pl/androidjava/save-presentation/">Zapisz prezentację</a></li>
<li><a href="/slides/pl/androidjava/convert-powerpoint-to-pdf/">Konwertuj do PDF</a></li>
<li><a href="/slides/pl/androidjava/convert-slide/">Renderuj slajdy jako obrazy</a></li>
<li><a href="/slides/pl/androidjava/manage-text/">Edytuj tekst i kształty</a></li>
</ul>
<p>PROCESY SLIDE'ÓW</p>
<ul>
<li><a href="/slides/pl/androidjava/powerpoint-charts/">Wykresy</a></li>
<li><a href="/slides/pl/androidjava/powerpoint-animation/">Animacje</a></li>
<li><a href="/slides/pl/androidjava/manage-media-files/">Audio i wideo</a></li>
<li><a href="/slides/pl/androidjava/presentation-design/">Projektowanie slajdów</a></li>
<li><a href="/slides/pl/androidjava/merge-presentation/">Scalanie prezentacji</a></li>
</ul>
<p>PRZYKŁADY</p>
<ul>
<li><a href="/slides/pl/androidjava/examples/">Przykłady według elementu slajdu</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Dokumentacja i Wsparcie</b></p>
<hr>
<p>DOKUMENTACJA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/androidjava/">Referencja API</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/release-notes/">Informacje o wydaniu</a></li>
<li><a href="/slides/pl/androidjava/known-issues/">Znane problemy</a></li>
<li><a href="https://products.aspose.com/slides/android-java/">Strona produktu</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/">Pobierz</a></li>
</ul>
<p>WSPARCIE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Darmowe forum wsparcia</a></li>
<li><a href="https://helpdesk.aspose.com/">Płatny helpdesk wsparcia</a></li>
</ul>
</div>
</div>

------

## **Twoja pierwsza prezentacja**

Biblioteka pochodzi z repozytorium Maven firmy Aspose. Nowe projekty Android Studio mają już blok `dependencyResolutionManagement` w *settings.gradle.kts*. Dodaj poniższą linię `maven` do bloku `repositories` wewnątrz niego, zamiast wklejać drugi blok:

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

Następnie dodaj bibliotekę do *app/build.gradle.kts* i zsynchronizuj projekt:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

[Instalacja](/slides/pl/androidjava/install-aspose-slides-for-android-via-java/) zawiera skrypty budowania Groovy, ręczny plik JAR oraz informacje, jak wybrać wersję. Kod twojej pierwszej prezentacji znajduje się w [Utwórz prezentacje](/slides/pl/androidjava/create-presentation/): dodaje on pole tekstowe do slajdu i zapisuje prezentację w pamięci aplikacji. Ten przykład został skompilowany i utworzony jako plik APK; nie został uruchomiony na urządzeniu. Bez licencji zapisane prezentacje zawierają znak wodny oceny — zobacz [Licencjonowanie](/slides/pl/androidjava/licensing/).