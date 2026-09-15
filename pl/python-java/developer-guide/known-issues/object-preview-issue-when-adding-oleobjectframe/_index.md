---
title: "Problem z podglądem obiektu przy dodawaniu OleObjectFrame"
linktitle: "Problem z obiektem OLE"
type: docs
weight: 10
url: /pl/python-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- "problem z podglądem"
- "osadzony obiekt"
- "osadzony plik"
- "obiekt zmieniony"
- "podgląd obiektu"
- PowerPoint
- "prezentacja"
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, dlaczego pojawia się komunikat EMBEDDED OLE OBJECT podczas dodawania OleObjectFrame w Aspose.Slides for Python via Java oraz jak naprawić problemy z podglądem w prezentacjach PPT, PPTX i ODP."
---
## **Wprowadzenie**

Kiedy używasz Aspose.Slides for Python via Java, aby dodać [OleObjectFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleobjectframe/) do slajdu, na wyjściowym slajdzie wyświetlany jest komunikat „EMBEDDED OLE OBJECT”. Ten komunikat jest zamierzony i nie jest błędem.

Aby uzyskać więcej informacji na temat pracy z obiektami OLE, zobacz [Zarządzaj OLE](/slides/pl/python-java/manage-ole/).

## **Wyjaśnienie i rozwiązanie**

Aspose.Slides wyświetla komunikat „EMBEDDED OLE OBJECT”, aby poinformować Cię, że obiekt OLE został zmieniony i trzeba zaktualizować jego podglądowy obraz.

Na przykład, jeśli dodasz wykres Microsoft Excel jako [OleObjectFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleobjectframe/) do slajdu (aby uzyskać więcej szczegółów, zobacz artykuł „Manage OLE”) i następnie otworzysz prezentację w Microsoft PowerPoint, zobaczysz ten obraz na slajdzie:

![Komunikat obiektu OLE](OLE_object_message.png)

Aby potwierdzić, że obiekt OLE został dodany do slajdu, dwukrotnie kliknij komunikat „EMBEDDED OLE OBJECT”, lub kliknij go prawym przyciskiem i wybierz **Object > Edit**.

![Obiekt OLE > Edytuj](OLE_object_edit.png)

PowerPoint otwiera następnie wbudowany obiekt OLE.

![Dane obiektu OLE](OLE_object_data.png)

Slajd może nadal wyświetlać komunikat „EMBEDDED OLE OBJECT”. Po kliknięciu obiektu OLE podgląd slajdu zostaje zaktualizowany, a komunikat „EMBEDDED OLE OBJECT” zostaje zastąpiony rzeczywistym obrazem obiektu OLE.

![Podgląd obiektu OLE](OLE_object_preview.png)

Zapisz prezentację, aby zachować zaktualizowany podglądowy obraz obiektu OLE. Po ponownym otwarciu prezentacji nie zobaczysz już komunikatu „EMBEDDED OLE OBJECT”.

## **Inne rozwiązanie**

Jeśli nie chcesz usuwać komunikatu „EMBEDDED OLE OBJECT” poprzez otwarcie prezentacji w PowerPoint i zapisanie jej, możesz zastąpić komunikat własnym wybranym obrazem podglądu. Poniższy kod demonstruje ten proces:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("embeddedOLE.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Dodaj obraz do zasobów prezentacji.
    image = Images.fromFile("myImage.png")
    try:
        ole_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Ustaw tytuł i obraz podglądu obiektu OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(False)

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Slajd zawierający [OleObjectFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleobjectframe/) zmienia się wtedy na następujący:

![Nowy obraz obiektu OLE](OLE_object_new_image.png)

## **FAQ**

**Dlaczego pojawia się komunikat „EMBEDDED OLE OBJECT”?**

Komunikat wskazuje, że obiekt OLE został zmieniony i jego podglądowy obraz wymaga aktualizacji. To zachowanie jest zamierzone.

**Jak mogę zaktualizować podgląd w PowerPoint?**

Dwukrotnie kliknij komunikat lub wybierz **Object > Edit**, aby otworzyć wbudowany obiekt OLE. Kliknij obiekt OLE, aby zaktualizować podgląd, a następnie zapisz prezentację.

**Czy mogę zastąpić komunikat bez otwierania prezentacji w PowerPoint?**

Tak. Możesz przypisać wybrany obraz podglądu do obiektu OLE, jak pokazano w powyższym przykładzie kodu.