---
title: Zabezpieczanie prezentacji przed zapisem w Pythonie
linktitle: Ochrona przed zapisem
type: docs
weight: 25
url: /pl/python-net/write-protected-presentation/
keywords:
- ochrona przed zapisem
- ochrona przed zapisem PowerPoint
- hasło do modyfikacji
- ogranicz edycję prezentacji
- usuń ochronę przed zapisem
- zweryfikuj hasło modyfikacji
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Ustawiaj, wykrywaj, weryfikuj i usuwaj hasła ochrony przed zapisem w prezentacjach PowerPoint PPT i PPTX przy użyciu Aspose.Slides dla Pythona."
---
## **Wprowadzenie**

Hasło ochrony przed zapisem ogranicza modyfikację prezentacji, ale nie szyfruje jej treści. Użytkownicy mogą ładować i przeglądać prezentację zabezpieczoną przed zapisem bez hasła. W zależności od aplikacji mogą również edytować zawartość i zapisać ją pod inną nazwą, dlatego ochrona przed zapisem nie powinna być traktowana jako mechanizm poufności.

Hasło otwierające pełni inną funkcję: szyfruje prezentację i jest wymagane do załadowania jej treści. Aby zaszyfrować prezentację lub zweryfikować hasło otwierające, zobacz [Password-Protect Presentations](/slides/pl/python-net/password-protected-presentation/).

Procedury opisane w tym artykule mają zastosowanie zarówno do prezentacji PPT, jak i PPTX. Przykłady używają plików PPTX; przy zapisie jako PPT użyj rozszerzenia `.ppt` i odpowiedniego formatu zapisu PPT.

## **Ustaw ochronę przed zapisem w prezentacji**

Użyj [ProtectionManager.set_write_protection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/set_write_protection/), aby przypisać hasło umożliwiające modyfikację prezentacji. Zapisanie prezentacji utrwala ustawienie ochrony.

Poniższy przykład ustawia ochronę przed zapisem w prezentacji PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.set_write_protection("modify_password")
    presentation.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Załaduj prezentację zabezpieczoną przed zapisem**

Ponieważ ochrona przed zapisem nie szyfruje treści prezentacji, nie jest wymagane żadne hasło do załadowania prezentacji. Hasło jest istotne jedynie przy weryfikacji uprawnienia do modyfikacji zabezpieczonej prezentacji.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Nie przekazuj hasła ochrony przed zapisem do [LoadOptions.password](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/password/). Właściwość ta przyjmuje hasło otwierające dla zaszyfrowanej treści. Jeśli prezentacja posiada oba typy ochrony, podaj hasło otwierające, aby ją załadować, a hasło ochrony przed zapisem obsłuż osobno.

## **Usuń ochronę przed zapisem w prezentacji**

Użyj [ProtectionManager.remove_write_protection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/remove_write_protection/), aby usunąć ograniczenie modyfikacji, a następnie zapisz prezentację.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    presentation.protection_manager.remove_write_protection()
    presentation.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Sprawdź, czy prezentacja jest zabezpieczona przed zapisem**

Aby przejrzeć plik bez tworzenia pełnego obiektu [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/), wywołaj [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationfactory/get_presentation_info/) i sprawdź [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/is_write_protected/). Właściwość wykorzystuje [NullableBool](https://reference.aspose.com/slides/pl/python-net/aspose.slides/nullablebool/) i zwraca `NullableBool.TRUE`, gdy wykryto ochronę przed zapisem.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected == slides.NullableBool.TRUE:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

Przeciążenie metodą strumienia [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationfactory/get_presentation_info/) dostarcza tych samych informacji dla prezentacji podanej jako strumień.

## **Zweryfikuj hasło ochrony przed zapisem**

Użyj [PresentationInfo.check_write_protection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/check_write_protection/), aby zweryfikować hasło modyfikacji bez ładowania pełnej prezentacji. Najpierw sprawdź [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/is_write_protected/), aby aplikacja żądała lub weryfikowała hasło tylko wtedy, gdy istnieje ochrona przed zapisem.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected != slides.NullableBool.TRUE:
    print("The presentation is not write protected.")
elif presentation_info.check_write_protection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.check_write_protection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/check_write_protection/) weryfikuje wyłącznie hasło ochrony przed zapisem. Nie weryfikuje hasła otwierającego ani nie określa, czy zaszyfrowana treść może zostać załadowana. Z kolei [PresentationInfo.check_password](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/check_password/) weryfikuje jedynie hasło otwierające. Jeśli pełna prezentacja została już załadowana, [ProtectionManager.check_write_protection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/check_write_protection/) zapewnia równoważną kontrolę ochrony przed zapisem poprzez menedżera ochrony.

W aplikacjach produkcyjnych nie loguj haseł ani nie umieszczaj ich w komunikatach diagnostycznych. Unikaj niepotrzebnych, powtarzalnych prób weryfikacji i przechowuj hasła w pamięci tylko tak długo, jak jest to niezbędne.

{{% alert color="info" title="Zobacz także" %}}
- [Password-Protect Presentations](/slides/pl/python-net/password-protected-presentation/)
- [Read-Only Presentations](/slides/pl/python-net/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/pl/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Czy ochrona przed zapisem szyfruje prezentację?**

Nie. Ogranicza modyfikację, ale pozostawia treść prezentacji dostępną do załadowania i przeglądania.

**Czy hasło ochrony przed zapisem jest wymagane do otwarcia prezentacji?**

Nie. Do załadowania zaszyfrowanej treści prezentacji wymagane jest jedynie hasło otwierające.

**Czy prezentacja może mieć jednocześnie hasło otwierające i hasło ochrony przed zapisem?**

Tak. Dostarcz hasło otwierające za pośrednictwem opcji ładowania, aby otworzyć zaszyfrowaną prezentację, oraz osobno zweryfikuj hasło ochrony przed zapisem, gdy wymagane jest zezwolenie na modyfikację.