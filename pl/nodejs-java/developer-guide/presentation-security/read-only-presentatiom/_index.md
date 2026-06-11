---
title: Zapis prezentacji w trybie tylko do odczytu przy użyciu JavaScript
linktitle: Prezentacja tylko do odczytu
type: docs
weight: 30
url: /pl/nodejs-java/read-only-presentation/
keywords:
- tylko do odczytu
- chronić prezentację
- zapobiegać edycji
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Ładuj i zapisuj pliki PowerPoint w trybie tylko do odczytu przy użyciu Aspose.Slides for Node.js via Java, oferując precyzyjne podglądy slajdów bez modyfikacji Twoich prezentacji."
---
## **Wprowadzenie**

W programie PowerPoint 2019 firma Microsoft wprowadziła ustawienie **Always Open Read-Only** jako jedną z opcji, które użytkownicy mogą wykorzystać do zabezpieczenia swoich prezentacji. Możesz chcieć użyć tego ustawienia Tryb Tylko do odczytu, aby chronić prezentację, gdy

- Chcesz zapobiec przypadkowym edycjom i zachować treść prezentacji w bezpieczeństwie. 
- Chcesz ostrzec odbiorców, że dostarczona prezentacja jest wersją końcową. 

Po wybraniu opcji **Always Open Read-Only** dla prezentacji, gdy użytkownicy otwierają prezentację, widzą zalecenie **Read-Only** i mogą zobaczyć komunikat w następującej formie: *Aby zapobiec przypadkowym zmianom, autor ustawił ten plik jako otwierany w trybie tylko do odczytu.*

Zalecenie **Read-Only** jest prostym, ale skutecznym odstraszaczem, które zniechęca do edycji, ponieważ użytkownicy muszą wykonać pewne działanie, aby je usunąć, zanim będą mogli edytować prezentację. Jeśli nie chcesz, aby użytkownicy wprowadzali zmiany w prezentacji i chcesz poinformować ich o tym w uprzejmy sposób, zalecenie **Read-Only** może być dla Ciebie dobrą opcją. 

> Jeśli prezentacja z zabezpieczeniem **Read-Only** zostanie otwarta w starszej aplikacji Microsoft PowerPoint — która nie obsługuje niedawno wprowadzonej funkcji — zalecenie **Read-Only** zostaje zignorowane (prezentacja jest otwierana normalnie).

## **Zastosuj tryb tylko do odczytu**

Aspose.Slides for Node.js via Java umożliwia ustawienie prezentacji jako **Read-Only**, co oznacza, że użytkownicy (po otwarciu prezentacji) widzą zalecenie **Read-Only**. Ten przykładowy kod pokazuje, jak ustawić prezentację jako **Read-Only** w JavaScript przy użyciu Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 

**Uwaga**: Zalecenie **Read-Only** ma po prostu na celu zniechęcenie do edycji lub powstrzymanie użytkowników przed wprowadzaniem przypadkowych zmian w prezentacji PowerPoint. Jeśli zmotywowana osoba — która wie, co robi — zdecyduje się edytować Twoją prezentację, może łatwo usunąć ustawienie Read-Only. Jeśli naprawdę musisz zapobiec nieautoryzowanej edycji, lepiej jest używać [bardziej rygorystycznych zabezpieczeń obejmujących szyfrowanie i hasła](https://docs.aspose.com/slides/pl/nodejs-java/password-protected-presentation/).

{{% /alert %}} 

## **FAQ**

**Jak różni się 'Read-Only recommended' od pełnej ochrony hasłem?**

'Read-Only recommended' wyświetla jedynie sugestię otwarcia pliku w trybie tylko do odczytu i jest łatwe do obejścia. [Ochrona hasłem](/slides/pl/nodejs-java/password-protected-presentation/) faktycznie ogranicza otwieranie lub edycję i jest odpowiednia, gdy potrzebujesz rzeczywistych kontroli bezpieczeństwa.

**Czy 'Read-Only recommended' można połączyć z znakami wodnymi, aby jeszcze bardziej zniechęcić do edycji?**

Tak. Zalecenie można połączyć z [znakami wodnymi](/slides/pl/nodejs-java/watermark/) jako wizualnym odstraszaczem; są to odrębne mechanizmy i dobrze współdziałają.

**Czy makro lub zewnętrzne narzędzie może nadal modyfikować plik, gdy zalecenie jest włączone?**

Tak. Zalecenie nie blokuje zmian programowych. Aby zapobiec automatycznym edycjom, użyj [haseł i szyfrowania](/slides/pl/nodejs-java/password-protected-presentation/).

**Jak 'Read-Only recommended' odnosi się do flag 'IsEncrypted' i 'IsWriteProtected'?**

Są to różne sygnały. 'Read-Only recommended' to miękka, opcjonalna podpowiedź; [isWriteProtected](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/protectionmanager/iswriteprotected/) i [isEncrypted](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/protectionmanager/isencrypted/) wskazują rzeczywiste ograniczenia zapisu lub odczytu, które zależą od haseł lub szyfrowania.