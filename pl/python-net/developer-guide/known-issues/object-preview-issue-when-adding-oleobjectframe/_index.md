---
title: Problem z podglądem obiektu przy dodawaniu OleObjectFrame
linktitle: Problem z obiektem OLE
type: docs
weight: 10
url: /pl/python-net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problem z podglądem
- osadzony obiekt
- osadzony plik
- zmieniony obiekt
- podgląd obiektu
- prezentacja
- PowerPoint
- Python
- Aspose.Slides
description: "Dowiedz się, dlaczego pojawia się komunikat EMBEDDED OLE OBJECT przy dodawaniu OleObjectFrame w Aspose.Slides for Python oraz jak naprawić problemy z podglądem w prezentacjach PPT, PPTX i ODP."
---
## **Wprowadzenie**

Korzystając z Aspose.Slides for Python via .NET, gdy dodasz [OleObjectFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/oleobjectframe/) do slajdu, na wyjściowym slajdzie pojawia się komunikat „EMBEDDED OLE OBJECT”. Ten komunikat jest zamierzony i NIE jest błędem.

Aby uzyskać więcej informacji na temat pracy z obiektami OLE, zobacz [Manage OLE](/slides/pl/python-net/manage-ole/).

## **Wyjaśnienie i rozwiązanie**

Aspose.Slides wyświetla komunikat „EMBEDDED OLE OBJECT”, aby powiadomić Cię, że obiekt OLE został zmieniony i należy zaktualizować obraz podglądu.

Na przykład, jeśli dodasz wykres Microsoft Excel jako [OleObjectFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/oleobjectframe/) do slajdu (więcej szczegółów znajdziesz w artykule „Manage OLE”) i następnie otworzysz prezentację w Microsoft PowerPoint, zobaczysz ten obraz na slajdzie:

![OLE object message](OLE_object_message.png)

Jeśli chcesz sprawdzić i potwierdzić, że Twój obiekt OLE został dodany do slajdu, musisz dwukrotnie kliknąć komunikat „EMBEDDED OLE OBJECT”, albo możesz kliknąć prawym przyciskiem i wybrać opcję **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint otwiera wtedy osadzony obiekt OLE.

![OLE object data](OLE_object_data.png)

Slajd może zachować komunikat „EMBEDDED OLE OBJECT”. Po kliknięciu obiektu OLE podgląd slajdu zostaje zaktualizowany, a komunikat „EMBEDDED OLE OBJECT” zostaje zastąpiony rzeczywistym obrazem obiektu OLE.

![OLE object preview](OLE_object_preview.png)

Teraz możesz chcieć zapisać prezentację, aby upewnić się, że obraz obiektu OLE został zaktualizowany prawidłowo. W ten sposób po zapisaniu prezentacji i ponownym jej otwarciu nie zobaczysz komunikatu „EMBEDDED OLE OBJECT”.

## **Inne rozwiązania**

### **Rozwiązanie 1: Zastąp komunikat „Embedded OLE Object” obrazem**

Jeśli nie chcesz usuwać komunikatu „EMBEDDED OLE OBJECT” przez otwarcie prezentacji w PowerPoint i jej zapisanie, możesz zastąpić ten komunikat wybranym obrazem podglądu. Poniższe linie kodu demonstrują proces:

```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Dodaj obraz do zasobów prezentacji.
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # Ustaw tytuł i obraz podglądu obiektu OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```

Slajd zawierający `OleObjectFrame` zmieni się wtedy na:

![New OLE object image](OLE_object_new_image.png)

### **Rozwiązanie 2: Utwórz dodatek dla PowerPoint**

Możesz również stworzyć dodatek dla Microsoft PowerPoint, który aktualizuje wszystkie obiekty OLE przy otwieraniu prezentacji w programie.