---
title: Zapis prezentacji w trybie tylko do odczytu przy użyciu C++
linktitle: Prezentacja tylko do odczytu
type: docs
weight: 30
url: /pl/cpp/read-only-presentation/
keywords:
- tylko do odczytu
- zabezpiecz prezentację
- zapobiegaj edycji
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Ładuj i zapisuj pliki PowerPoint (PPT, PPTX) w trybie tylko do odczytu przy użyciu Aspose.Slides for C++, oferując precyzyjne podglądy slajdów bez zmiany Twoich prezentacji."
---
## **Wprowadzenie**

W PowerPoint 2019 firma Microsoft wprowadziła ustawienie **Always Open Read-Only** jako jedną z opcji, które użytkownicy mogą wykorzystać do ochrony swoich prezentacji. Możesz chcieć używać tego ustawienia **Read-Only**, aby chronić prezentację, gdy

- Chcesz zapobiec przypadkowym edycjom i zabezpieczyć zawartość prezentacji. 
- Chcesz poinformować odbiorców, że udostępniona prezentacja jest wersją końcową. 

Po wybraniu opcji **Always Open Read-Only** dla prezentacji, gdy użytkownicy otworzą plik, zobaczą rekomendację **Read-Only** i mogą zobaczyć komunikat w takiej formie: *Aby zapobiec przypadkowym zmianom, autor ustawił ten plik jako otwierany w trybie tylko do odczytu.*

Rekomendacja **Read-Only** jest prostym, lecz skutecznym środkiem odstraszającym od edycji, ponieważ użytkownicy muszą wykonać dodatkowy krok, aby usunąć tę rekomendację, zanim będą mogli edytować prezentację. Jeśli nie chcesz, aby użytkownicy wprowadzali zmiany w prezentacji i chcesz poinformować ich o tym w uprzejmy sposób, rekomendacja **Read-Only** może być dla Ciebie dobrą opcją. 

> Jeśli prezentacja zabezpieczona **Read-Only** zostanie otwarta w starszej wersji programu Microsoft PowerPoint, która nie obsługuje niedawno wprowadzonej funkcji, rekomendacja **Read-Only** zostanie zignorowana (prezentacja zostanie otwarta normalnie).

## **Zastosowanie trybu tylko do odczytu**

Aspose.Slides for C++ umożliwia ustawienie prezentacji jako **Read-Only**, co oznacza, że użytkownicy (po otwarciu prezentacji) zobaczą rekomendację **Read-Only**. Poniższy przykładowy kod pokazuje, jak ustawić prezentację jako **Read-Only** w C++ przy użyciu Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="primary" %}} 

**Uwaga**: Rekomendacja **Read-Only** ma po prostu na celu zniechęcenie do edycji lub zapobieganie przypadkowym zmianom w prezentacji PowerPoint. Jeśli zmotywowana osoba—znająca się na tym—zdecyduje się edytować Twoją prezentację, może łatwo usunąć ustawienie tylko do odczytu. Jeśli naprawdę musisz zapobiec nieautoryzowanej edycji, lepiej użyć [bardziej rygorystycznych zabezpieczeń obejmujących szyfrowanie i hasła](https://docs.aspose.com/slides/pl/cpp/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Czym różni się „Read-Only recommended” od pełnej ochrony hasłem?**

„Read-Only recommended” wyświetla jedynie sugestię otwarcia pliku w trybie tylko do odczytu i jest łatwa do obejścia. [Password protection](/slides/pl/cpp/password-protected-presentation/) faktycznie ogranicza otwieranie lub edycję i jest odpowiednia, gdy potrzebne są rzeczywiste zabezpieczenia.

**Czy „Read-Only recommended” można połączyć z znakami wodnymi, aby jeszcze bardziej zniechęcić do edycji?**

Tak. Rekomendację można połączyć z [watermarks](/slides/pl/cpp/watermark/) jako wizualnym środkiem odstraszającym; są to odrębne mechanizmy, które dobrze ze sobą współpracują.

**Czy makro lub zewnętrzne narzędzie nadal może modyfikować plik, gdy włączona jest rekomendacja?**

Tak. Rekomendacja nie blokuje zmian programistycznych. Aby zapobiec automatycznym edycjom, użyj [passwords and encryption](/slides/pl/cpp/password-protected-presentation/).

**Jak „Read-Only recommended” odnosi się do flag „is encrypted” i „is write protected”?**

Są to różne sygnały. „Read-Only recommended” to miękka, opcjonalna prośba; [get_IsWriteProtected](https://reference.aspose.com/slides/pl/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) i [get_IsEncrypted](https://reference.aspose.com/slides/pl/cpp/aspose.slides/protectionmanager/get_isencrypted/) wskazują rzeczywiste ograniczenia zapisu lub odczytu, które zależą od haseł lub szyfrowania.