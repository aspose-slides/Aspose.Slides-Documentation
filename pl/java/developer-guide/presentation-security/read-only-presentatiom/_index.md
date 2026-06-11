---
title: Zapisz prezentacje w trybie tylko do odczytu przy użyciu Javy
linktitle: Prezentacja tylko do odczytu
type: docs
weight: 30
url: /pl/java/read-only-presentation/
keywords:
- tylko do odczytu
- ochrona prezentacji
- zapobieganie edycji
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Ładuj i zapisuj pliki PowerPoint (PPT, PPTX) w trybie tylko do odczytu przy użyciu Aspose.Slides dla Javy, oferując precyzyjne podglądy slajdów bez modyfikacji prezentacji."
---
## **Wprowadzenie**

W PowerPoint 2019 firma Microsoft wprowadziła opcję **Always Open Read-Only** jako jedną z możliwości ochrony prezentacji. Możesz chcieć użyć tego ustawienia tylko do odczytu, aby chronić prezentację, gdy

- Chcesz zapobiec przypadkowym zmianom i zabezpieczyć treść prezentacji.  
- Chcesz poinformować odbiorców, że udostępniona prezentacja jest wersją końcową.  

Po wybraniu opcji **Always Open Read-Only** dla prezentacji, gdy użytkownicy otwierają plik, widzą zalecenie **Read-Only** i mogą zobaczyć komunikat w formie: *Aby zapobiec przypadkowym zmianom, autor ustawił ten plik jako otwierany w trybie tylko do odczytu.*

Zalecenie **Read-Only** jest prostym, lecz skutecznym środkiem odstraszającym edycję, ponieważ użytkownicy muszą wykonać dodatkowy krok, aby usunąć to ograniczenie przed edycją prezentacji. Jeśli nie chcesz, aby użytkownicy wprowadzali zmiany w prezentacji i chcesz przekazać im tę informację w uprzejmy sposób, zalecenie **Read-Only** może być dla Ciebie dobrą opcją.

> Jeśli prezentacja z ochroną **Read-Only** zostanie otwarta w starszej wersji Microsoft PowerPoint, która nie obsługuje niedawno wprowadzonej funkcji, zalecenie **Read-Only** zostanie zignorowane (prezentacja otworzy się normalnie).

## **Zastosowanie trybu tylko do odczytu**

Aspose.Slides for Java umożliwia ustawienie prezentacji jako **Read-Only**, co oznacza, że użytkownicy (po otwarciu prezentacji) zobaczą zalecenie **Read-Only**. Poniższy przykładowy kod pokazuje, jak w Javie przy użyciu Aspose.Slides ustawić prezentację jako **Read-Only**:

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

**Uwaga**: Zalecenie **Read-Only** ma jedynie na celu zniechęcenie do edycji lub zapobieganie przypadkowym zmianom w prezentacji PowerPoint. Jeśli zmotywowana osoba—która wie, co robi—zdecyduje się edytować Twoją prezentację, może łatwo usunąć to ustawienie. Jeśli naprawdę musisz uniemożliwić nieautoryzowaną edycję, lepiej skorzystać z [more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/pl/java/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Czym różni się „Read-Only recommended” od pełnej ochrony hasłem?**

„Read-Only recommended” wyświetla jedynie sugestię otwierania pliku w trybie tylko do odczytu i jest łatwa do obejścia. [Password protection](/slides/pl/java/password-protected-presentation/) faktycznie ogranicza otwieranie lub edycję i jest odpowiednia, gdy potrzebne są prawdziwe mechanizmy zabezpieczające.

**Czy „Read-Only recommended” można połączyć z znakami wodnymi, aby dodatkowo zniechęcić do edycji?**

Tak. Zalecenie można połączyć z [watermarks](/slides/pl/java/watermark/) jako wizualnym środkiem odstraszającym; są to odrębne mechanizmy i dobrze współdziałają.

**Czy makro lub zewnętrzne narzędzie nadal mogą modyfikować plik, gdy włączone jest zalecenie?**

Tak. Zalecenie nie blokuje zmian programistycznych. Aby zapobiec automatycznej edycji, użyj [passwords and encryption](/slides/pl/java/password-protected-presentation/).

**Jak „Read-Only recommended” odnosi się do metod `isEncrypted` i `isWriteProtected`?**

Są to różne sygnały. „Read-Only recommended” to miękka, opcjonalna sugestia; [isWriteProtected](https://reference.aspose.com/slides/pl/java/com.aspose.slides/protectionmanager/#isWriteProtected--) i [isEncrypted](https://reference.aspose.com/slides/pl/java/com.aspose.slides/protectionmanager/#isEncrypted--) wskazują rzeczywiste ograniczenia zapisu lub odczytu, które zależą od haseł lub szyfrowania.