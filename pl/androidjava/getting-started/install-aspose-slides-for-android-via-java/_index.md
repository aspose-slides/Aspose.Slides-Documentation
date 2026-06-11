---
title: Instalacja Aspose.Slides for Android via Java
type: docs
weight: 90
url: /pl/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- zainstaluj Aspose.Slides
- pobierz Aspose.Slides
- użyj Aspose.Slides
- instalacja Aspose.Slides
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Szybko zainstaluj Aspose.Slides for Android. Przewodnik krok po kroku, wymagania systemowe i przykłady kodu Java — rozpocznij pracę z prezentacjami PowerPoint już dziś!"
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zainstalować Aspose.Slides for Android via Java i dodać go do projektu Android. Opisuje dwie opcje instalacji: ręczne dodanie pliku JAR Aspose.Slides do projektu oraz instalację biblioteki z repozytorium Maven.

Artykuł zawiera również przykład krok po kroku, który pokazuje, jak utworzyć nową aplikację Android w Android Studio, odwołać się do biblioteki Aspose.Slides, programowo stworzyć prezentację PowerPoint i zapisać ją w formacie PPTX. Zawiera także uwagi dotyczące wersjonowania oraz odpowiedzi na najczęstsze pytania o weryfikację integracji, zarządzanie zużyciem pamięci i zmniejszanie ostatecznego rozmiaru pliku JAR.

## **Instalacja**
Wcześniej Aspose.Slides for Android via Java był dystrybuowany jako pojedynczy plik ZIP zawierający plik JAR, dema i dokumentację produktu.

1. Jeśli chcesz używać wersji starszej niż Aspose.Words for Android via Java 18.9, musisz rozpakować plik Aspose.Slides.Android.zip do wybranego katalogu.  
1. Dodaj wyodrębniony plik JAR do aplikacji, używając konfiguracji Build Path.  

### **Dodaj odwołanie do Aspose.Slides for Android via Java Jar**
1. Pobierz najnowszą wersję [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/pl/androidjava)  
1. Skopiuj aspose-slides-18.9-android.via.java.jar do folderu *libs/* w swoim projekcie  

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)

### **Zainstaluj Aspose.Slides for Android via Java z repozytorium Maven**
1. Dodaj repozytorium Maven do pliku build.gradle.  
1. Dodaj JAR [Aspose.Slides for Android via Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) jako zależność.  

``` java

 // 1. Dodaj repozytorium Maven do swojego pliku build.gradle 

repositories {

    mavenCentral()

    maven { url "https://releases.aspose.com/java/repo/" }

}

// 2. Dodaj plik JAR 'Aspose.Slides for Android via Java' jako zależność

dependencies {

    ...

    ...

    compile (group: 'com.aspose', name: 'aspose-slides', version: 'XX.XX', classifier: 'android.via.java')

}

```
## **Twoja pierwsza aplikacja z użyciem Aspose.Slides for Android via Java**
W tej sekcji dowiesz się, jak rozpocząć pracę z Aspose.Slides for Android via Java. Pokażemy, jak skonfigurować nowy projekt Android od podstaw, dodać odwołanie do pliku JAR Aspose.Slides oraz utworzyć nową prezentację PowerPoint, która zostanie zapisana na dysku w formacie PPTX. Przykład używa [Android Studio](https://developer.android.com/studio/index.html) do tworzenia i uruchamia aplikację w emulatorze Android. Aby rozpocząć pracę z Aspose.Slides for Android via Java, postępuj zgodnie z tym samouczkiem krok po kroku:

1. Pobierz i zainstaluj [Android Studio](https://developer.android.com/studio/index.html) w dowolnym miejscu.  
1. Uruchom Android Studio.  
1. Utwórz nowy projekt aplikacji Android.  

![todo:image_alt_text](install-aspose-slides-for-android-via-java_3.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_4.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_5.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_6.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_7.png)

1. Skopiuj aspose-slides-XX.XX-android.via.java.jar do folderu libs/ w swoim projekcie  

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)

1. Wybierz sekcję Projekt (z menu plik) i przejdź do zakładki Zależności.  
   1. Kliknij przycisk „+”. Wybierz opcję zależności od pliku.  
   1. Wybierz bibliotekę Aspose.Slides z folderu libs i kliknij OK.  

![todo:image_alt_text](install-aspose-slides-for-android-via-java_10.png)

1. W razie potrzeby zsynchronizuj projekt z plikami Gradle.  

![todo:image_alt_text](install-aspose-slides-for-android-via-java_11.png)

1. Aby uzyskać dostęp do karty SD, należy dodać specjalne uprawnienia. Otwórz plik AndroidManifest.xml i przejdź do widoku XML. Dodaj następującą linię:<uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />  

![todo:image_alt_text](install-aspose-slides-for-android-via-java_12.png)

1. Przejdź z powrotem do sekcji kodu aplikacji i dodaj następujące importy:  

``` java

 import java.io.File;

import com.aspose.slides.IAutoShape;

import com.aspose.slides.IParagraph;

import com.aspose.slides.IPortion;

import com.aspose.slides.ISlide;

import com.aspose.slides.ITextFrame;

import com.aspose.slides.Presentation;

import com.aspose.slides.SaveFormat;

import com.aspose.slides.ShapeType;

import android.os.Environment; 

```

Teraz wstaw ten kod do ciała metody onCreate, aby utworzyć nową prezentację od podstaw przy użyciu Aspose.Slides i zapisać ją na karcie SD w formacie PPTX.

``` java

 try

{

    // Utwórz instancję klasy Presentation reprezentującej PPTX
    Presentation pres = new Presentation();



    // Uzyskaj dostęp do pierwszego slajdu
    ISlide sld = pres.getSlides().get_Item(0);



    // Dodaj AutoShape typu Prostokąt
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);



    // Dodaj TextFrame do prostokąta
    ashp.addTextFrame(" ");



    // Uzyskiwanie dostępu do ramki tekstowej
    ITextFrame txtFrame = ashp.getTextFrame();



    // Utwórz obiekt Paragraph dla ramki tekstowej
    IParagraph para = txtFrame.getParagraphs().get_Item(0);



    // Utwórz obiekt Portion dla akapitu
    IPortion portion = para.getPortions().get_Item(0);



    // Ustaw tekst
    portion.setText("Aspose TextBox");



    // Zapisz plik PPTX na karcie
    String sdCardPath = Environment.getExternalStorageDirectory().getPath() + File.separator;
    pres.save(sdCardPath + "Textbox.pptx",SaveFormat.Pptx);
}

catch (Exception e)

{
   e.printStackTrace();
}
```

Pełny kod powinien wyglądać tak:

![todo:image_alt_text](install-aspose-slides-for-android-via-java_13.png)

1. Uruchom aplikację ponownie. Tym razem kod Aspose.Slides zostanie wykonany w tle i wygeneruje dokument, który zostanie zapisany na karcie SD.  

![todo:image_alt_text](install-aspose-slides-for-android-via-java_14.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_15.jpg)

1. Aby zobaczyć utworzony dokument, przejdź do menu Narzędzia. Wybierz Android, a następnie Android Device Monitor  

![todo:image_alt_text](install-aspose-slides-for-android-via-java_16.jpg)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_17.jpg)

## **Wersjonowanie**
Od 2018 roku wersjonowanie Aspose.Slides for Android via Java jest zgodne z wersjonowaniem Aspose.Slides for Java.  

## **FAQ**

**Jak mogę zweryfikować, że Aspose.Slides został poprawnie zintegrowany?**

Zbuduj projekt, utwórz pusty [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) i zapisz go pod nową nazwą. Jeśli plik zostanie utworzony bez wyjątków, biblioteka została pomyślnie zintegrowana.

**Jak mogę ograniczyć zużycie pamięci podczas przetwarzania dużych prezentacji?**

Podnoś limity pamięci JVM tylko tak wysoko, jak to konieczne, i zamykaj każdą instancję [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) w bloku `finally`, aby niezwłocznie zwolnić pamięć podręczną. Zapobiega to błędom „out‑of‑memory” i utrzymuje przewidywalne zużycie pamięci podczas operacji wsadowych.

**Czy mogę wykluczyć niepotrzebne formaty eksportu, aby zmniejszyć ostateczny rozmiar pliku JAR?**

Obecne wersje Aspose.Slides są dostarczane jako jedna monolityczna biblioteka, więc nie można wyłączyć konkretnych eksporterów, takich jak PDF czy SVG, w czasie kompilacji.