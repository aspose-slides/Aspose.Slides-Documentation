---
title: Zabezpiecz prezentacje hasłem w JavaScript
linktitle: Ochrona hasłem
type: docs
weight: 20
url: /pl/nodejs-java/password-protected-presentation/
keywords:
- prezentacja zabezpieczona hasłem
- hasło otwierające
- szyfruj PowerPoint
- odszyfruj PowerPoint
- sprawdź hasło prezentacji
- weryfikuj hasło prezentacji
- otwórz zaszyfrowaną prezentację
- usuń szyfrowanie
- PowerPoint
- PPT
- PPTX
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Szyfruj, wykrywaj, waliduj, otwieraj i odszyfrowuj prezentacje PowerPoint PPT i PPTX zabezpieczone hasłem w JavaScript przy użyciu Aspose.Slides."
---
## **Przegląd**

Hasło otwierające szyfruje prezentację. Poprawne hasło jest wymagane do załadowania i wyświetlenia zawartości prezentacji, więc to zabezpieczenie zapewnia poufność.

Hasło otwierające różni się od hasła ochrony przed zapisem. Ochrona przed zapisem ogranicza modyfikację, ale nie szyfruje treści ani nie uniemożliwia załadowania prezentacji. Aby zarządzać hasłami do modyfikacji prezentacji, zobacz [Zabezpiecz prezentacje przed zapisem](/slides/pl/nodejs-java/write-protected-presentation/).

Poniższe przepływy pracy mają zastosowanie zarówno do prezentacji PPT, jak i PPTX. Przykłady używają obu formatów, gdy ich zachowanie oparte na plikach i strumieniach ma znaczenie.

## **Szyfruj prezentację za pomocą hasła otwierającego**

Użyj [ProtectionManager.encrypt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/protectionmanager/#encrypt), aby przypisać hasło otwierające. Następnie użyj [Presentation.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save), aby zapisać zaszyfrowaną prezentację.

Poniższy przykład szyfruje prezentację PPTX:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Załaduj zaszyfrowaną prezentację**

Ustaw [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#setPassword) na hasło otwierające i przekaż opcje do [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) podczas ładowania pliku. Ładowanie nie powiodło się, gdy wymagane jest hasło otwierające, ale podane hasło jest brakujące lub nieprawidłowe.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Pracuj z odszyfrowaną prezentacją.
} finally {
    presentation.dispose();
}
```

## **Usuń szyfrowanie z prezentacji**

Załaduj prezentację przy użyciu jej hasła otwierającego, wywołaj [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) i zapisz wynik. Zapisana prezentacja może być następnie ładowana bez hasła.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sprawdź hasło otwierające przed załadowaniem**

Użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo), aby uzyskać [PresentationInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/) bez tworzenia pełnej instancji prezentacji. Sprawdź [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) przed żądaniem lub walidacją hasła. Gdy ochrona jest obecna, zweryfikuj podaną wartość za pomocą [PresentationInfo.checkPassword](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/#checkPassword).

### **Przepływ pracy z ścieżką do pliku**

Poniższy przykład weryfikuje hasło otwierające dla pliku PPTX, przekazuje zweryfikowaną wartość do [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#setPassword) i następnie ładuje pełną prezentację:

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "protected-presentation.pptx";
const password = "open_password";
const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    console.log("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    console.log("The opening password is incorrect.");
} else {
    const loadOptions = new slides.LoadOptions();
    loadOptions.setPassword(password);

    const presentation = new slides.Presentation(filePath, loadOptions);
    try {
        console.log("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Przepływ pracy ze strumieniem**

Użyj [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream), aby sprawdzić odczytywalny strumień Node.js. Po zużyciu strumienia inspekcji, utwórz nowy strumień przed załadowaniem pełnej prezentacji za pomocą [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#createPresentationFromStream).

Poniższy przykład używa pliku PPT:

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");

const filePath = "protected-presentation.ppt";
const password = "open_password";
const presentationFactory = slides.PresentationFactory.getInstance();
const infoStream = fs.createReadStream(filePath);

slides.PresentationFactory.getPresentationInfoFromStream(presentationFactory, infoStream, function(infoError, presentationInfo) {
    if (infoError) {
        console.log("The presentation information could not be read: " + infoError.message);
    } else if (!presentationInfo.isPasswordProtected()) {
        console.log("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        console.log("The opening password is incorrect.");
    } else {
        const loadOptions = new slides.LoadOptions();
        loadOptions.setPassword(password);
        const presentationStream = fs.createReadStream(filePath);

        slides.Presentation.createPresentationFromStream(presentationStream, loadOptions, function(loadError, presentation) {
            if (loadError) {
                console.log("The presentation could not be loaded: " + loadError.message);
            } else {
                try {
                    console.log("The presentation was validated and loaded successfully.");
                } finally {
                    presentation.dispose();
                }
            }
        });
    }
});
```

### **Wartości zwracane przez checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/#checkPassword) zwraca `true` tylko wtedy, gdy prezentacja posiada hasło otwierające i podane hasło jest prawidłowe. Zwraca `false` w każdym z następujących przypadków:

- Hasło jest nieprawidłowe.
- Prezentacja nie posiada hasła otwierającego.
- Podane hasło jest `null` lub puste.

Zachowanie jest takie samo dla prezentacji PPT i PPTX.

## **Sprawdź, czy załadowana prezentacja jest zaszyfrowana**

Po załadowaniu prezentacji przy użyciu poprawnego hasła, sprawdź [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/protectionmanager/#isEncrypted), aby potwierdzić, że źródłowa prezentacja była zaszyfrowana. Aby wykryć ochronę hasłem otwierającym przed załadowaniem, użyj [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) jak pokazano powyżej.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const isEncrypted = presentation.getProtectionManager().isEncrypted();
    console.log("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Zalecenia dotyczące bezpieczeństwa**

{{% alert color="warning" title="Security" %}}
Nie zapisuj haseł otwierających w logach ani nie umieszczaj ich w komunikatach diagnostycznych. Unikaj niepotrzebnych powtarzających się prób weryfikacji, przechowuj hasła w pamięci tylko tak długo, jak jest to potrzebne, oraz używaj ponownie wyniku udanej weryfikacji przy natychmiastowym ładowaniu prezentacji.
{{% /alert %}}

## **Zabezpiecz prezentację hasłem online**

1. Otwórz aplikację [Aspose.Slides Lock](https://products.aspose.app/slides/pl/lock).
2. Wybierz lub prześlij prezentację.
3. Wprowadź hasło chroniące podgląd.
4. Opcjonalnie wprowadź osobne hasło chroniące edycję.
5. Zastosuj ochronę i pobierz powstały plik.

{{% alert color="info" title="See also" %}}
- [Zabezpiecz prezentacje przed zapisem](/slides/pl/nodejs-java/write-protected-presentation/)
- [Podpis cyfrowy w programie PowerPoint](/slides/pl/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Jaka jest różnica między hasłem otwierającym a hasłem ochrony przed zapisem?**

Hasło otwierające szyfruje prezentację i jest wymagane do załadowania jej zawartości. Hasło ochrony przed zapisem ogranicza modyfikację bez szyfrowania treści.

**Czy mogę zweryfikować hasło otwierające bez ładowania wszystkich slajdów?**

Tak. Uzyskaj informacje o prezentacji, sprawdź, czy występuje ochrona hasłem otwierającym, i zweryfikuj hasło przed utworzeniem pełnej instancji prezentacji.

**Czy przepływy weryfikacji hasła obsługują zarówno PPT, jak i PPTX?**

Tak. Wykrywanie i weryfikacja hasła oparte na ścieżce pliku oraz strumieniu zachowują się tak samo dla prezentacji PPT i PPTX.