---
title: Zarządzanie kontrolkami ActiveX w prezentacjach na Androidzie
linktitle: ActiveX
type: docs
weight: 80
url: /pl/androidjava/activex/
keywords:
- ActiveX
- kontrolka ActiveX
- zarządzanie ActiveX
- dodawanie ActiveX
- modyfikacja ActiveX
- odtwarzacz multimedialny
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Edytuj pola tekstowe i przyciski ActiveX, aktualizuj podglądy kontrolek oraz ponownie użyj kontrolki Windows Media Player w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Androida w języku Java."
---
## **Wprowadzenie**

ActiveX controls dają slajdowi PowerPoint elementy interaktywne, takie jak pola tekstowe, przyciski poleceń i odtwarzacze multimediów. Aspose.Slides for Android via Java udostępnia kontrolki slajdu poprzez [IBaseSlide.getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getControls--). Użyj tej kolekcji, aby edytować kontrolkę, przenieść ją na slajdzie lub usunąć. W poniższych przykładach użyj ścieżek do plików, które Twoja aplikacja Android może odczytać, i wybierz lokalizację zapisu dla każdej wyjściowej prezentacji.

## **Lista kontrolek ActiveX i ich przechowywanych właściwości**

Aby zbadać nieznany szablon, otwórz go do odczytu i przeiteruj kontrolki na każdym slajdzie. Przykład podaje numer slajdu, nazwę kontrolki, [getClassId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getClassId--), oraz każdą parę klucz-wartość w [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--). Odczytuje prezentację bez aktywowania kontrolek, wywoływania zdarzeń czy makr, zmieniania wartości ani zapisywania pliku.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    for (int i = 0; i < presentation.getSlides().size(); i++) {
        for (IControl control : presentation.getSlides().get_Item(i).getControls()) {
            System.out.printf("Slide %d | %s | %s%n", i + 1, control.getName(), control.getClassId());
            IControlPropertiesCollection properties = control.getProperties();
            if (properties == null) {
                System.out.println("  Properties unavailable");
                continue;
            }
            if (properties.getCount() == 0) {
                System.out.println("  []");
            }
            for (String name : properties.getNamesOfProperties()) {
                System.out.printf("  %s = %s%n", name, properties.get_Item(name));
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Wybrany wynik z `ActiveX.pptm` pokazuje pole tekstowe i przycisk polecenia.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Pusta kolekcja właściwości pojawia się jako `[]`. Dla kontrolek używających binarnego przechowywania, [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--) może zwrócić `null`, wyświetlane jako `Properties unavailable`. Jeśli potrzebujesz tylko nazw, użyj [getNamesOfProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) po sprawdzeniu na `null`. Raport wymienia właściwości dostępne w prezentacji. Kontrolka może obsługiwać dodatkowe właściwości w czasie wykonywania.

## **Modyfikacja kontrolek ActiveX**

Przykład wymaga prezentacji z włączonymi makrami, zawierającej pole tekstowe o nazwie `TextBox1` oraz przycisk polecenia o nazwie `CommandButton1` na pierwszym slajdzie. Używa [kolekcja właściwości kontrolki](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) do zmiany wartości pola tekstowego i napisu przycisku. Każda kontrolka ma również statyczny podgląd, który PowerPoint może wyświetlić przed aktywacją. Dostarcz PNG dla każdej kontrolki pokazujący zaktualizowany tekst i wygląd. Przykład przypisuje te obrazy poprzez [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getSubstitutePictureFormat--).

Przykład przesuwa każdą kontrolkę na pierwszym slajdzie w dół o 100 punktów, ustawiając jej ramkę za pomocą [IControl.setFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-). Zapisuje edytowaną prezentację w formacie PPTM, a następnie używa [IControlCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolcollection/#clear--) aby zapisać drugą kopię z usuniętymi wszystkimi kontrolkami ActiveX z tego slajdu.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    IControlCollection controls = presentation.getSlides().get_Item(0).getControls();
    IControl textBox = null;
    IControl button = null;
    for (IControl control : controls) {
        if ("TextBox1".equals(control.getName())) {
            textBox = control;
        } else if ("CommandButton1".equals(control.getName())) {
            button = control;
        }
    }
    if (textBox == null || button == null || textBox.getProperties() == null || button.getProperties() == null) {
        System.out.println("The first slide must contain both named controls with editable properties.");
        return;
    }

    IPPImage textBoxPreview;
    IPPImage buttonPreview;
    try (FileInputStream textBoxStream = new FileInputStream("text-box-preview.png");
         FileInputStream buttonStream = new FileInputStream("button-preview.png")) {
        textBoxPreview = presentation.getImages().addImage(textBoxStream);
        buttonPreview = presentation.getImages().addImage(buttonStream);
    }
    textBox.getProperties().set_Item("Value", "Changed text");
    button.getProperties().set_Item("Caption", "Show message");
    textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
    button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

    for (IControl control : controls) {
        IShapeFrame frame = control.getFrame();
        ShapeFrame moved = new ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation());
        control.setFrame(moved);
    }
    presentation.save("edited-controls.pptm", SaveFormat.Pptm);

    controls.clear();
    presentation.save("removed-controls.pptm", SaveFormat.Pptm);
} catch (IOException e) {
    System.out.println("Could not read a control preview: " + e.getMessage());
} finally {
    presentation.dispose();
}
```

## **Dodanie kontrolki odtwarzacza multimedialnego ActiveX**

Aby ponownie użyć skonfigurowanej kontrolki Windows Media Player, zacznij od szablonu, którego pierwszy slajd zawiera odtwarzacz o nazwie `WindowsMediaPlayer1`. [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) kopiuje cały slajd do nowej prezentacji. Przykład ustawia `URL` odtwarzacza w jego [kolekcja właściwości](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) i zapisuje sklonowany slajd jako jedyny slajd w wyjściu. Wideo pozostaje zewnętrzne, więc wybierz ścieżkę, do której odtwarzacz będzie miał dostęp podczas odtwarzania.

```java
import com.aspose.slides.*;

Presentation template = new Presentation("template.pptx");
try {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().addClone(template.getSlides().get_Item(0));
        IControl player = null;
        for (IControl control : slide.getControls()) {
            if ("WindowsMediaPlayer1".equals(control.getName())) {
                player = control;
                break;
            }
        }
        if (player == null || player.getProperties() == null) {
            System.out.println("The template slide must contain a named media player with editable properties.");
            return;
        }
        player.getProperties().set_Item("URL", "Wildlife.mp4");

        presentation.getSlides().removeAt(0);
        presentation.save("linked-video.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    template.dispose();
}
```

## **FAQ**

**Czy Aspose.Slides może zachować kontrolki ActiveX bez ich uruchamiania?**

Tak. Aspose.Slides może odczytywać i zapisywać kontrolki, wraz z ich właściwościami i pozycjami, bez ich aktywacji.

**Czym różnią się kontrolki ActiveX od obiektów OLE?**

Kontrolki ActiveX pozwalają użytkownikom wchodzić w interakcję ze slajdem, na przykład wprowadzając tekst lub klikając przycisk. Obiekt [obiekt OLE](/slides/pl/androidjava/manage-ole/) pozwala slajdowi zawierać lub łączyć się z treścią zarządzaną przez inną aplikację, taką jak arkusz Excel.

**Czy zdarzenia ActiveX nadal wywołają makra VBA po zapisaniu prezentacji przy użyciu Aspose.Slides?**

Zapisz prezentację w formacie obsługującym makra, takim jak PPTM, aby zachować projekt VBA. PowerPoint dla systemu Windows może uruchamiać istniejące obsługiwacze zdarzeń, gdy ustawienia zabezpieczeń zezwalają zarówno na kontrolki ActiveX, jak i na makra.