---
title: Zabezpieczanie prezentacji przed zapisem w Javie
linktitle: Ochrona przed zapisem
type: docs
weight: 25
url: /pl/java/write-protected-presentation/
keywords:
  - ochrona przed zapisem
  - zabezpieczanie PowerPoint przed zapisem
  - hasło do modyfikacji
  - ogranicz edycję prezentacji
  - usuń ochronę przed zapisem
  - zweryfikuj hasło modyfikacji
  - PowerPoint
  - prezentacja
  - Java
  - Aspose.Slides
description: "Ustawiaj, wykrywaj, weryfikuj i usuwaj hasła zabezpieczające przed zapisem w prezentacjach PowerPoint PPT i PPTX przy użyciu Aspose.Slides dla Javy."
---
## **Wprowadzenie**

Hasło ochrony przed zapisem ogranicza modyfikację prezentacji, ale nie szyfruje jej zawartości. Użytkownicy mogą wczytać i przeglądać prezentację zabezpieczoną przed zapisem bez podania hasła. W zależności od aplikacji mogą również edytować zawartość i zapisać ją pod inną nazwą, dlatego ochrona przed zapisem nie powinna być traktowana jako mechanizm poufności.

Hasło otwierające służy innemu celowi: szyfruje prezentację i jest wymagane do wczytania jej zawartości. Aby zaszyfrować prezentację lub zweryfikować hasło otwierające, zobacz [Password‑Protect Presentations](/slides/pl/java/password-protected-presentation/).

Procedury opisane w tym artykule mają zastosowanie zarówno do prezentacji PPT, jak i PPTX. Przykłady używają plików PPTX; przy zapisywaniu jako PPT użyj rozszerzenia `.ppt` i odpowiedniego formatu zapisu PPT.

## **Ustaw ochronę przed zapisem w prezentacji**

Użyj [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) aby przypisać hasło do modyfikacji prezentacji. Zapisanie prezentacji utrwala ustawienie ochrony.

Poniższy przykład ustawia ochronę przed zapisem w prezentacji PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Wczytaj prezentację zabezpieczoną przed zapisem**

Ponieważ ochrona przed zapisem nie szyfruje zawartości prezentacji, nie jest wymagane żadne hasło do wczytania prezentacji. Hasło jest istotne tylko przy weryfikacji uprawnień do modyfikacji zabezpieczonej prezentacji.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Nie przekazuj hasła ochrony przed zapisem do [ILoadOptions.setPassword](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-). Ta metoda przyjmuje hasło otwierające dla zaszyfrowanej zawartości. Jeśli prezentacja ma oba typy ochrony, podaj hasło otwierające, aby ją wczytać, a hasło ochrony przed zapisem obsłuż osobno.

## **Usuń ochronę przed zapisem w prezentacji**

Użyj [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) aby usunąć ograniczenie modyfikacji, a następnie zapisz prezentację.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sprawdź, czy prezentacja jest zabezpieczona przed zapisem**

Aby sprawdzić plik bez tworzenia pełnego obiektu [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/), wywołaj [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) i sprawdź [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--). Metoda używa [NullableBool](https://reference.aspose.com/slides/pl/java/com.aspose.slides/nullablebool/) i zwraca `NullableBool.True`, gdy wykryta jest ochrona przed zapisem.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() == NullableBool.True) {
    System.out.println("The presentation is write protected.");
} else {
    System.out.println("Write protection was not detected.");
}
```

Przeciążenie metodą strumieniową [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) dostarcza tę samą informację dla prezentacji podanej jako strumień.

## **Zwaliduj hasło ochrony przed zapisem**

Użyj [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-), aby zweryfikować hasło modyfikacji bez wczytywania pełnej prezentacji. Najpierw sprawdź [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--), aby aplikacja żądała lub weryfikowała hasło tylko wtedy, gdy istnieje ochrona przed zapisem.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) weryfikuje wyłącznie hasło ochrony przed zapisem. Nie weryfikuje hasła otwierającego ani nie określa, czy zaszyfrowana zawartość może zostać wczytana. Natomiast [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) weryfikuje wyłącznie hasło otwierające. Jeśli pełna prezentacja została już wczytana, [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) zapewnia równoważną kontrolę ochrony przed zapisem za pośrednictwem menedżera ochrony.

W aplikacjach produkcyjnych nie loguj haseł ani nie umieszczaj ich w komunikatach diagnostycznych. Unikaj niepotrzebnych wielokrotnych prób weryfikacji i przechowuj hasła w pamięci tylko tak długo, jak jest to potrzebne.

{{% alert color="info" title="Zobacz także" %}}
- [Zabezpieczanie prezentacji hasłem](/slides/pl/java/password-protected-presentation/)
- [Prezentacje tylko do odczytu](/slides/pl/java/read-only-presentation/)
- [Podpis cyfrowy w PowerPoint](/slides/pl/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Czy ochrona przed zapisem szyfruje prezentację?**

Nie. Ogranicza modyfikację, ale pozostawia zawartość prezentacji dostępną do wczytania i obejrzenia.

**Czy hasło ochrony przed zapisem jest wymagane do otwarcia prezentacji?**

Nie. Do wczytania zaszyfrowanej zawartości prezentacji wymagane jest jedynie hasło otwierające.

**Czy prezentacja może mieć jednocześnie hasło otwierające i hasło ochrony przed zapisem?**

Tak. Podaj hasło otwierające w opcjach wczytywania, aby otworzyć zaszyfrowaną prezentację, a hasło ochrony przed zapisem zweryfikuj osobno, gdy wymagane jest uprawnienie do modyfikacji.