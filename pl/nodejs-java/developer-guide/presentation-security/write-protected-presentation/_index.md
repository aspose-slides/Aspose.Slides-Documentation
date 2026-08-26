---
title: Zabezpiecz prezentacje przed zapisem w JavaScript
linktitle: Ochrona przed zapisem
type: docs
weight: 25
url: /pl/nodejs-java/write-protected-presentation/
keywords:
- ochrona przed zapisem
- ochrona przed zapisem PowerPoint
- hasło do modyfikacji
- ograniczenie edycji prezentacji
- usunięcie ochrony przed zapisem
- weryfikacja hasła modyfikacji
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Ustawiaj, wykrywaj, weryfikuj i usuwaj hasła ochrony przed zapisem w prezentacjach PowerPoint PPT i PPTX przy użyciu Aspose.Slides dla Node.js w Javie."
---
## **Wprowadzenie**

Hasło ochrony przed zapisem ogranicza modyfikację prezentacji, ale nie szyfruje jej zawartości. Użytkownicy mogą wczytać i wyświetlić prezentację chronioną przed zapisem bez podania hasła. W zależności od aplikacji, mogą również edytować zawartość i zapisać ją pod inną nazwą, dlatego ochrona przed zapisem nie powinna być traktowana jako mechanizm poufności.

Hasło otwierające pełni inną rolę: szyfruje prezentację i jest wymagane do wczytania jej zawartości. Aby zaszyfrować prezentację lub zweryfikować hasło otwierające, zobacz [Password-Protect Presentations](/slides/pl/nodejs-java/password-protected-presentation/).

Procedury opisane w tym artykule mają zastosowanie zarówno do prezentacji PPT, jak i PPTX. Przykłady używają plików PPTX; przy zapisywaniu jako PPT użyj rozszerzenia `.ppt` oraz odpowiedniego formatu zapisu PPT.

## **Ustaw ochronę przed zapisem w prezentacji**

Użyj [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/protectionmanager/#setWriteProtection), aby przypisać hasło do modyfikacji prezentacji. Zapisanie prezentacji utrwala ustawienie ochrony.

Poniższy przykład ustawia ochronę przed zapisem w prezentacji PPTX:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Wczytaj prezentację chronioną przed zapisem**

Ponieważ ochrona przed zapisem nie szyfruje zawartości prezentacji, nie jest wymagane hasło do wczytania prezentacji. Hasło ma znaczenie wyłącznie przy weryfikacji uprawnienia do modyfikacji chronionej prezentacji.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Nie przekazuj hasła ochrony przed zapisem do [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#setPassword). Ta metoda przyjmuje hasło otwierające dla zaszyfrowanej zawartości. Jeśli prezentacja posiada oba typy ochrony, podaj hasło otwierające, aby ją wczytać, a hasło ochrony przed zapisem obsłuż oddzielnie.

## **Usuń ochronę przed zapisem z prezentacji**

Użyj [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/protectionmanager/#removeWriteProtection), aby usunąć ograniczenie modyfikacji, a następnie zapisz prezentację.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sprawdź, czy prezentacja jest chroniona przed zapisem**

Aby sprawdzić plik bez tworzenia pełnej instancji [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/), wywołaj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) i przejrzyj [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected). Metoda używa [NullableBool](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/nullablebool/) i zwraca `NullableBool.True`, gdy wykryto ochronę przed zapisem.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() === slides.NullableBool.True) {
    console.log("The presentation is write protected.");
} else {
    console.log("Write protection was not detected.");
}
```

Metoda strumieniowa [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) dostarcza tych samych informacji dla prezentacji przekazanej jako strumień odczytu Node.js.

## **Walidacja hasła ochrony przed zapisem**

Użyj [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection), aby zweryfikować hasło modyfikacji bez wczytywania pełnej prezentacji. Najpierw sprawdź [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected), aby aplikacja żądała lub weryfikowała hasło tylko wtedy, gdy istnieje ochrona przed zapisem.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() !== slides.NullableBool.True) {
    console.log("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    console.log("The write-protection password is correct.");
} else {
    console.log("The write-protection password is incorrect.");
}
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) weryfikuje wyłącznie hasło ochrony przed zapisem. Nie weryfikuje hasła otwierającego ani nie określa, czy zaszyfrowaną zawartość można wczytać. Natomiast [PresentationInfo.checkPassword](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/#checkPassword) weryfikuje jedynie hasło otwierające. Jeśli pełna prezentacja została już wczytana, [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/protectionmanager/#checkWriteProtection) dostarcza równoważną kontrolę ochrony przed zapisem poprzez menedżer ochrony.

W aplikacjach produkcyjnych nie loguj haseł ani nie umieszczaj ich w komunikatach diagnostycznych. Unikaj niepotrzebnych powtórnych prób weryfikacji i przechowuj hasła w pamięci tylko tak długo, jak jest to konieczne.

{{% alert color="info" title="See also" %}}
- [Password-Protect Presentations](/slides/pl/nodejs-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/pl/nodejs-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/pl/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Czy ochrona przed zapisem szyfruje prezentację?**

Nie. Ogranicza modyfikację, ale pozostawia zawartość prezentacji dostępną do wczytania i wyświetlenia.

**Czy hasło ochrony przed zapisem jest wymagane do otwarcia prezentacji?**

Nie. Tylko hasło otwierające jest wymagane do wczytania zaszyfrowanej zawartości prezentacji.

**Czy prezentacja może mieć jednocześnie hasło otwierające i hasło ochrony przed zapisem?**

Tak. Podaj hasło otwierające w opcjach ładowania, aby otworzyć zaszyfrowaną prezentację, oraz zweryfikuj hasło ochrony przed zapisem oddzielnie, gdy wymagane jest uprawnienie do modyfikacji.