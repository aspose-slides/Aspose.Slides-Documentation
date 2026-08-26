---
title: Zabezpieczanie prezentacji hasłem w Javie
linktitle: Ochrona hasłem
type: docs
weight: 20
url: /pl/java/password-protected-presentation/
keywords:
- prezentacja zabezpieczona hasłem
- hasło otwierające
- szyfrowanie PowerPoint
- odszyfrowywanie PowerPoint
- walidacja hasła prezentacji
- sprawdzanie hasła prezentacji
- otwieranie zaszyfrowanej prezentacji
- usuwanie szyfrowania
- PowerPoint
- PPT
- PPTX
- prezentacja
- Java
- Aspose.Slides
description: "Szyfruj, wykrywaj, weryfikuj, otwieraj i odszyfrowuj prezentacje PowerPoint PPT i PPTX zabezpieczone hasłem w języku Java przy użyciu Aspose.Slides."
---
## **Przegląd**

Hasło otwierające szyfruje prezentację. Poprawne hasło jest wymagane do załadowania i wyświetlenia zawartości prezentacji, więc ta ochrona zapewnia poufność.

Hasło otwierające różni się od hasła ochrony przed zapisem. Ochrona przed zapisem ogranicza modyfikację, ale nie szyfruje zawartości ani nie uniemożliwia załadowania prezentacji. Aby zarządzać hasłami służącymi do modyfikacji prezentacji, zobacz [Write-Protect Presentations](/slides/pl/java/write-protected-presentation/).

Poniższe przepływy pracy mają zastosowanie zarówno do prezentacji PPT, jak i PPTX. Przykłady używają obu formatów, gdy ich zachowanie oparte na plikach i strumieniach ma znaczenie.

## **Szyfrowanie prezentacji przy użyciu hasła otwierającego**

Użyj [IProtectionManager.encrypt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) aby przypisać hasło otwierające. Następnie użyj [IPresentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) aby zapisać zaszyfrowaną prezentację.

Poniższy przykład szyfruje prezentację PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ładowanie zaszyfrowanej prezentacji**

Ustaw [ILoadOptions.setPassword](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) na hasło otwierające i przekaż opcje do [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) podczas ładowania pliku. Ładowanie nie powiedzie się, gdy wymagane jest hasło otwierające, ale podane hasło jest nieobecne lub nieprawidłowe.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Pracuj z odszyfrowaną prezentacją.
} finally {
    presentation.dispose();
}
```

## **Usunięcie szyfrowania z prezentacji**

Załaduj prezentację przy użyciu jej hasła otwierającego, wywołaj [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprotectionmanager/#removeEncryption--), i zapisz wynik. Zapisana prezentacja może następnie być ładowana bez hasła.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Walidacja hasła otwierającego przed ładowaniem**

Użyj [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-), aby uzyskać [IPresentationInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationinfo/) bez tworzenia pełnej instancji prezentacji. Sprawdź [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) przed żądaniem lub walidacją hasła. Gdy ochrona jest obecna, zweryfikuj podaną wartość za pomocą [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Przepływ pracy z ścieżką pliku**

Poniższy przykład waliduje hasło otwierające dla pliku PPTX, przekazuje zweryfikowaną wartość do [ILoadOptions.setPassword](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-), a następnie ładuje pełną prezentację:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;

String filePath = "protected-presentation.pptx";
String password = "open_password";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    System.out.println("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    System.out.println("The opening password is incorrect.");
} else {
    LoadOptions loadOptions = new LoadOptions();
    loadOptions.setPassword(password);

    Presentation presentation = new Presentation(filePath, loadOptions);
    try {
        System.out.println("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Przepływ pracy ze strumieniem**

Przeciążenie strumieniowe [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) zapewnia ten sam przepływ pracy. Zresetuj pozycję strumienia obsługującego szukanie przed załadowaniem pełnej prezentacji z tego strumienia.

Poniższy przykład używa pliku PPT:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import java.io.FileInputStream;

String password = "open_password";

FileInputStream presentationStream = new FileInputStream("protected-presentation.ppt");
try {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(presentationStream);

    if (!presentationInfo.isPasswordProtected()) {
        System.out.println("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        System.out.println("The opening password is incorrect.");
    } else {
        presentationStream.getChannel().position(0);

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setPassword(password);

        Presentation presentation = new Presentation(presentationStream, loadOptions);
        try {
            System.out.println("The presentation was validated and loaded successfully.");
        } finally {
            presentation.dispose();
        }
    }
} finally {
    presentationStream.close();
}
```

### **Wartości zwracane przez checkPassword**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) zwraca `true` tylko wtedy, gdy prezentacja ma hasło otwierające i podane hasło jest prawidłowe. Zwraca `false` we wszystkich następujących przypadkach:

- Hasło jest nieprawidłowe.
- Prezentacja nie posiada hasła otwierającego.
- Podane hasło jest `null` lub puste.

Zachowanie jest takie samo dla prezentacji PPT i PPTX.

## **Sprawdzenie, czy załadowana prezentacja jest szyfrowana**

Po załadowaniu prezentacji przy użyciu prawidłowego hasła, sprawdź [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) aby potwierdzić, że źródłowa prezentacja była zaszyfrowana. Aby wykryć ochronę hasłem otwierającym przed ładowaniem, użyj `IPresentationInfo.isPasswordProtected`, jak pokazano powyżej.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
    System.out.println("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Zalecenia dotyczące bezpieczeństwa**

{{% alert color="warning" title="Security" %}}
Nie rejestruj haseł otwierających ani nie umieszczaj ich w komunikatach diagnostycznych. Unikaj niepotrzebnych powtarzających się prób weryfikacji, przechowuj hasła w pamięci tylko tak długo, jak jest to potrzebne, i ponownie używaj pomyślnego wyniku weryfikacji przy natychmiastowym ładowaniu prezentacji.
{{% /alert %}}

## **Zabezpieczenie prezentacji hasłem online**

1. Otwórz aplikację [Aspose.Slides Lock](https://products.aspose.app/slides/pl/lock).
1. Wybierz lub prześlij prezentację.
1. Wprowadź hasło chroniące widok.
1. Opcjonalnie wprowadź osobne hasło chroniące edycję.
1. Zastosuj ochronę i pobierz wynikowy plik.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/pl/java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/pl/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Jaka jest różnica między hasłem otwierającym a hasłem ochrony przed zapisem?**

Hasło otwierające szyfruje prezentację i jest wymagane do załadowania jej zawartości. Hasło ochrony przed zapisem ogranicza modyfikację bez szyfrowania zawartości.

**Czy mogę zweryfikować hasło otwierające bez ładowania wszystkich slajdów?**

Tak. Uzyskaj informacje o prezentacji, sprawdź, czy istnieje ochrona hasłem otwierającym, i zweryfikuj hasło przed utworzeniem pełnej instancji prezentacji.

**Czy przepływy weryfikacji hasła obsługują zarówno PPT, jak i PPTX?**

Tak. Wykrywanie i weryfikacja hasła oparte na ścieżce pliku oraz strumieniu zachowują się tak samo dla prezentacji PPT i PPTX.