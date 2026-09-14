---
title: Zabezpiecz prezentacje przed zapisem w Pythonie
linktitle: Ochrona przed zapisem
type: docs
weight: 25
url: /pl/python-java/write-protected-presentation/
keywords:
- ochrona przed zapisem
- ochrona przed zapisem PowerPoint
- hasło do modyfikacji
- ograniczenie edycji prezentacji
- usunięcie ochrony przed zapisem
- weryfikacja hasła modyfikacji
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Ustawiaj, wykrywaj, weryfikuj i usuwaj hasła ochrony przed zapisem w prezentacjach PowerPoint PPT i PPTX przy użyciu Aspose.Slides dla Pythona poprzez Java."
---
## **Wprowadzenie**

Hasło ochrony przed zapisem ogranicza modyfikację prezentacji, ale nie szyfruje jej treści. Użytkownicy mogą wczytać i wyświetlić prezentację chronioną przed zapisem bez podania hasła. W zależności od aplikacji mogą również edytować zawartość i zapisać ją pod inną nazwą, dlatego ochrona przed zapisem nie powinna być traktowana jako mechanizm poufności.

Hasło otwierające służy innemu celowi: szyfruje prezentację i jest wymagane do wczytania jej treści. Aby zaszyfrować prezentację lub zweryfikować hasło otwierające, zobacz [Prezentacje zabezpieczone hasłem](/slides/pl/python-java/password-protected-presentation/).

Procedury opisane w tym artykule dotyczą zarówno prezentacji PPT, jak i PPTX. Przykłady używają plików PPTX; przy zapisywaniu do formatu PPT użyj rozszerzenia `.ppt` oraz odpowiedniego formatu zapisu PPT.

## **Ustaw ochronę przed zapisem w prezentacji**

Użyj [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/protectionmanager/#setWriteProtection), aby przypisać hasło umożliwiające modyfikację prezentacji. Zapisanie prezentacji utrwala ustawienie ochrony.

Poniższy przykład ustawia ochronę przed zapisem w prezentacji PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().setWriteProtection("modify_password")
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Wczytaj prezentację chronioną przed zapisem**

Ponieważ ochrona przed zapisem nie szyfruje zawartości prezentacji, nie jest wymagane hasło do wczytania prezentacji. Hasło ma znaczenie tylko przy sprawdzaniu uprawnień do modyfikacji chronionej prezentacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("write-protected-pres.pptx")
try:
    print("Slide count: " + str(presentation.getSlides().size()))
finally:
    presentation.dispose()
```

Nie przekazuj hasła ochrony przed zapisem do [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#setPassword). Metoda ta przyjmuje hasło otwierające do zaszyfrowanej zawartości. Jeśli prezentacja posiada oba typy ochrony, podaj hasło otwierające, aby ją wczytać, a hasło ochrony przed zapisem obsłuż oddzielnie.

## **Usuń ochronę przed zapisem z prezentacji**

Użyj [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/protectionmanager/#removeWriteProtection), aby usunąć ograniczenie modyfikacji, a następnie zapisz prezentację.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("write-protected-pres.pptx")
try:
    presentation.getProtectionManager().removeWriteProtection()
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sprawdź, czy prezentacja jest chroniona przed zapisem**

Aby sprawdzić plik bez tworzenia pełnej instancji [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/), wywołaj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationfactory/#getPresentationInfo) i sprawdź [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/#isWriteProtected). Metoda używa [NullableBool](https://reference.aspose.com/slides/pl/python-java/aspose.slides/nullablebool/) i zwraca `NullableBool.True_`, gdy wykryto ochronę przed zapisem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() == NullableBool.True_:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

Przeciążenie strumieniowe [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationfactory/#getPresentationInfo) dostarcza te same informacje dla prezentacji podanej jako strumień.

## **Sprawdź poprawność hasła ochrony przed zapisem**

Użyj [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/#checkWriteProtection), aby zweryfikować hasło modyfikacji bez wczytywania pełnej prezentacji. Najpierw sprawdź [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/#isWriteProtected), aby aplikacja żądała lub weryfikowała hasło tylko wtedy, gdy istnieje ochrona przed zapisem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() != NullableBool.True_:
    print("The presentation is not write protected.")
elif presentation_info.checkWriteProtection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/#checkWriteProtection) sprawdza wyłącznie hasło ochrony przed zapisem. Nie weryfikuje hasła otwierającego ani nie określa, czy zaszyfrowana treść może zostać wczytana. Natomiast [PresentationInfo.checkPassword](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/#checkPassword) weryfikuje jedynie hasło otwierające. Jeśli pełna prezentacja została już wczytana, [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/protectionmanager/#checkWriteProtection) zapewnia równoważne sprawdzenie ochrony przed zapisem poprzez menedżer ochrony.

W aplikacjach produkcyjnych nie loguj haseł ani nie umieszczaj ich w komunikatach diagnostycznych. Unikaj niepotrzebnych powtarzających się prób weryfikacji i przechowuj hasła w pamięci tylko tak długo, jak jest to potrzebne.

{{% alert color="info" title="Zobacz także" %}}
- [Prezentacje zabezpieczone hasłem](/slides/pl/python-java/password-protected-presentation/)
- [Prezentacje tylko do odczytu](/slides/pl/python-java/read-only-presentation/)
- [Podpis cyfrowy w PowerPoint](/slides/pl/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Czy ochrona przed zapisem szyfruje prezentację?**

Nie. Ogranicza modyfikację, ale pozostawia zawartość prezentacji dostępną do wczytania i wyświetlenia.

**Czy hasło ochrony przed zapisem jest wymagane do otwarcia prezentacji?**

Nie. Do wczytania zaszyfrowanej zawartości prezentacji wymagane jest wyłącznie hasło otwierające.

**Czy prezentacja może mieć jednocześnie hasło otwierające i hasło ochrony przed zapisem?**

Tak. Podaj hasło otwierające poprzez opcje wczytywania, aby otworzyć zaszyfrowaną prezentację, a hasło ochrony przed zapisem zweryfikuj osobno, gdy wymagana jest autoryzacja do modyfikacji.