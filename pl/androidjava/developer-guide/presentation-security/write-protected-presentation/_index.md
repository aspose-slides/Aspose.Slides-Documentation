---
title: Zabezpieczanie prezentacji przed zapisem na Androidzie
linktitle: Ochrona przed zapisem
type: docs
weight: 25
url: /pl/androidjava/write-protected-presentation/
keywords:
- ochrona przed zapisem
- ochrona przed zapisem PowerPoint
- hasło do modyfikacji
- ograniczenie edycji prezentacji
- usunięcie ochrony przed zapisem
- weryfikacja hasła modyfikacji
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Ustawiaj, wykrywaj, weryfikuj i usuwaj hasła ochrony przed zapisem w prezentacjach PowerPoint PPT i PPTX przy użyciu Aspose.Slides dla Androida w języku Java."
---
## **Wprowadzenie**

Hasło zabezpieczające przed zapisem ogranicza modyfikację prezentacji, ale nie szyfruje jej treści. Użytkownicy mogą wczytać i przeglądać prezentację zabezpieczoną przed zapisem bez podania hasła. W zależności od aplikacji, mogą także edytować treść i zapisać ją pod inną nazwą, więc zabezpieczenie przed zapisem nie powinno być traktowane jako mechanizm poufności.

Hasło otwierające spełnia inną funkcję: szyfruje prezentację i jest wymagane do wczytania jej treści. Aby zaszyfrować prezentację lub zweryfikować hasło otwierające, zobacz [Password-Protect Presentations](/slides/pl/androidjava/password-protected-presentation/).

Procesy opisane w tym artykule dotyczą zarówno prezentacji PPT, jak i PPTX. Przykłady używają plików PPTX; przy zapisywaniu do PPT użyj rozszerzenia `.ppt` oraz odpowiadającego formatu zapisu PPT.

## **Ustaw ochronę przed zapisem w prezentacji**

Użyj [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) aby przypisać hasło do modyfikacji prezentacji. Zapisanie prezentacji zachowuje ustawienie ochrony.

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

Ponieważ ochrona przed zapisem nie szyfruje treści prezentacji, nie jest wymagane żadne hasło do wczytania prezentacji. Hasło ma znaczenie tylko podczas weryfikacji upoważnienia do modyfikacji zabezpieczonej prezentacji.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Nie przekazuj hasła ochrony przed zapisem do [ILoadOptions.setPassword](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-). Ta metoda przyjmuje hasło otwierające do zaszyfrowanej zawartości. Jeśli prezentacja ma oba typy ochrony, podaj hasło otwierające, aby ją wczytać, a hasło ochrony przed zapisem obsłuż osobno.

## **Usuń ochronę przed zapisem z prezentacji**

Użyj [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) aby usunąć ograniczenie modyfikacji, a następnie zapisz prezentację.

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

Aby sprawdzić plik bez tworzenia pełnej instancji [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/), wywołaj [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) i przeanalizuj [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--). Metoda używa [NullableBool](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/nullablebool/) i zwraca `NullableBool.True`, gdy wykryto ochronę przed zapisem.

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

Przeciążenie strumieniowe [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) dostarcza tych samych informacji dla prezentacji przekazanej jako strumień.

## **Sprawdź poprawność hasła ochrony przed zapisem**

Użyj [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-), aby zweryfikować hasło modyfikacji bez ładowania pełnej prezentacji. Najpierw sprawdź [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--), aby aplikacja żądała lub weryfikowała hasło tylko wtedy, gdy istnieje ochrona przed zapisem.

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

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) weryfikuje wyłącznie hasło ochrony przed zapisem. Nie weryfikuje hasła otwierającego ani nie określa, czy zaszyfrowana zawartość może zostać wczytana. Natomiast [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) weryfikuje wyłącznie hasło otwierające. Jeśli pełna prezentacja została już wczytana, [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) zapewnia równoważne sprawdzenie ochrony przed zapisem poprzez menedżer ochrony.

W aplikacjach produkcyjnych nie loguj haseł ani nie umieszczaj ich w komunikatach diagnostycznych. Unikaj niepotrzebnych powtarzających się prób weryfikacji i przechowuj hasła w pamięci tylko tak długo, jak jest to konieczne.

{{% alert color="info" title="Zobacz także" %}}
- [Prezentacje zabezpieczone hasłem](/slides/pl/androidjava/password-protected-presentation/)
- [Prezentacje tylko do odczytu](/slides/pl/androidjava/read-only-presentation/)
- [Podpis cyfrowy w PowerPoint](/slides/pl/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Czy ochrona przed zapisem szyfruje prezentację?**

Nie. Ogranicza modyfikację, ale pozostawia treść prezentacji dostępną do wczytania i przeglądania.

**Czy hasło ochrony przed zapisem jest wymagane do otwarcia prezentacji?**

Nie. Tylko hasło otwierające jest wymagane do wczytania zaszyfrowanej treści prezentacji.

**Czy prezentacja może mieć zarówno hasło otwierające, jak i hasło ochrony przed zapisem?**

Tak. Podaj hasło otwierające w opcjach ładowania, aby otworzyć zaszyfrowaną prezentację, oraz osobno zweryfikuj hasło ochrony przed zapisem, gdy wymagana jest autoryzacja do modyfikacji.