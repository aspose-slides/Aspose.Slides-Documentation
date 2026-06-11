---
title: Zapisz prezentacje w trybie tylko do odczytu na Androidzie
linktitle: Prezentacja tylko do odczytu
type: docs
weight: 30
url: /pl/androidjava/read-only-presentation/
keywords:
- tylko do odczytu
- ochrona prezentacji
- zapobieganie edycji
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Zapisz pliki PowerPoint (PPT, PPTX) w trybie tylko do odczytu przy użyciu Aspose.Slides for Android via Java, oferując precyzyjne podglądy slajdów bez modyfikacji twoich prezentacji."
---
## **Wprowadzenie**

W PowerPoint 2019 firma Microsoft wprowadziła opcję **Always Open Read-Only** jako jedną z możliwości ochrony prezentacji. Możesz chcieć używać tego ustawienia tylko do odczytu, aby chronić prezentację, gdy

- Chcesz zapobiec przypadkowym edycjom i zachować zawartość prezentacji w bezpieczeństwie. 
- Chcesz poinformować odbiorców, że udostępniona prezentacja jest wersją końcową. 

Po wybraniu opcji **Always Open Read-Only** dla prezentacji, gdy użytkownicy ją otwierają, zobaczą rekomendację **Read-Only** i mogą zobaczyć komunikat w tej formie: *Aby zapobiec przypadkowym zmianom, autor ustawił ten plik do otwarcia w trybie tylko do odczytu.*

Rekomendacja **Read-Only** jest prostym, a jednocześnie skutecznym środkiem odstraszającym od edycji, ponieważ użytkownicy muszą wykonać dodatkowy krok, aby ją usunąć przed możliwością edycji prezentacji. Jeśli nie chcesz, aby użytkownicy wprowadzali zmiany w prezentacji i chcesz przekazać im tę informację w uprzejmy sposób, rekomendacja **Read-Only** może być dla Ciebie dobrym rozwiązaniem. 

> Jeśli prezentacja z ochroną **Read-Only** zostanie otwarta w starszej wersji Microsoft PowerPoint — która nie obsługuje niedawno wprowadzonej funkcji — rekomendacja **Read-Only** zostanie zignorowana (prezentacja zostanie otwarta normalnie).

## **Zastosowanie trybu tylko do odczytu**

Aspose.Slides for Android via Java umożliwia ustawienie prezentacji jako **Read-Only**, co oznacza, że użytkownicy (po otwarciu prezentacji) zobaczą rekomendację **Read-Only**. Poniższy przykładowy kod pokazuje, jak w Javie ustawić prezentację jako **Read-Only** przy użyciu Aspose.Slides:

```java
Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

**Uwaga**: Rekomendacja **Read-Only** ma po prostu na celu zniechęcenie do edycji lub zapobieganie przypadkowym zmianom w prezentacji PowerPoint. Jeśli zmotywowana osoba, która wie, co robi, zdecyduje się edytować Twoją prezentację, może łatwo usunąć ustawienie Read-Only. Jeśli naprawdę musisz zapobiec nieautoryzowanej edycji, lepiej skorzystać z [bardziej rygorystycznych ochron, które obejmują szyfrowanie i hasła](https://docs.aspose.com/slides/pl/androidjava/password-protected-presentation/).

{{% /alert %}} 

## **FAQ**

**Czym różni się „Read-Only recommended” od pełnej ochrony hasłem?**

„Read-Only recommended” wyświetla jedynie sugestię otwarcia pliku w trybie tylko do odczytu i łatwo ją obejść. [Password protection](/slides/pl/androidjava/password-protected-presentation/) faktycznie ogranicza otwieranie lub edycję i jest odpowiednia, gdy potrzebujesz rzeczywistej kontroli bezpieczeństwa.

**Czy „Read-Only recommended” można połączyć z znakami wodnymi, aby jeszcze bardziej zniechęcić do edycji?**

Tak. Rekomendację można połączyć z [watermarks](/slides/pl/androidjava/watermark/) jako wizualnym środkiem odstraszania; są to odrębne mechanizmy, które dobrze ze sobą współpracują.

**Czy makro lub zewnętrzne narzędzie może nadal modyfikować plik, gdy rekomendacja jest włączona?**

Tak. Rekomendacja nie blokuje zmian programistycznych. Aby zapobiec automatycznym edycjom, użyj [passwords and encryption](/slides/pl/androidjava/password-protected-presentation/).

**Jak „Read-Only recommended” odnosi się do metod „isEncrypted” i „isWriteProtected”?**

Są to różne sygnały. „Read-Only recommended” jest miękkim, opcjonalnym monitorem; [isWriteProtected](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) i [isEncrypted](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) wskazują rzeczywiste ograniczenia zapisu lub odczytu, które zależą od haseł lub szyfrowania.