---
title: Zapisz prezentacje w trybie tylko do odczytu używając C++
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
description: "Wczytuj i zapisuj pliki PowerPoint (PPT, PPTX) w trybie tylko do odczytu przy użyciu Aspose.Slides for C++, zapewniając precyzyjne podglądy slajdów bez modyfikowania Twoich prezentacji."
---
## **Wprowadzenie**

W programie PowerPoint 2019 firma Microsoft wprowadziła ustawienie **Always Open Read-Only** jako jedną z opcji, które użytkownicy mogą wykorzystać do zabezpieczenia swoich prezentacji. Możesz chcieć użyć tego ustawienia Read-Only, aby chronić prezentację, gdy

- chcesz zapobiec przypadkowym edycjom i zapewnić bezpieczeństwo treści prezentacji.  
- chcesz poinformować odbiorców, że udostępniona przez Ciebie prezentacja jest wersją ostateczną.  

Po wybraniu opcji **Always Open Read-Only** dla prezentacji, gdy użytkownicy otworzą plik, zobaczą rekomendację **Read-Only** i mogą otrzymać komunikat w takiej postaci: *Aby zapobiec przypadkowym zmianom, autor ustawił ten plik do otwierania w trybie tylko do odczytu.*

Rekomendacja Read-Only jest prostym, a jednocześnie skutecznym środkiem odstraszającym od edycji, ponieważ użytkownicy muszą wykonać dodatkowy krok, aby ją usunąć, zanim będą mogli edytować prezentację. Jeśli nie chcesz, aby użytkownicy wprowadzali zmiany w prezentacji i chcesz poinformować ich o tym w uprzejmy sposób, rekomendacja Read-Only może być dla Ciebie dobrą opcją.  

> Jeśli prezentacja zabezpieczona rekomendacją **Read-Only** zostanie otwarta w starszej wersji Microsoft PowerPoint — która nie obsługuje tej nowej funkcji — rekomendacja **Read-Only** zostanie zignorowana (prezentacja zostanie otwarta normalnie).

## **Zastosowanie trybu Read-Only**

Aspose.Slides for C++ umożliwia ustawienie prezentacji jako **Read-Only**, co oznacza, że po otwarciu pliku użytkownicy zobaczą rekomendację **Read-Only**. Poniższy kod przykładowy pokazuje, jak w C++ ustawić prezentację jako **Read-Only** przy użyciu Aspose.Slides:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="info" %}} 

**Uwaga**: Rekomendacja **Read-Only** ma jedynie na celu zniechęcenie do edycji lub zapobieganie przypadkowym zmianom w prezentacji PowerPoint. Zmotywowana osoba — znająca się na rzeczy — może łatwo usunąć to ustawienie i edytować prezentację. Jeśli naprawdę musisz zapobiec nieautoryzowanej edycji, lepiej użyć [bardziej rygorystycznych zabezpieczeń wykorzystujących szyfrowanie i hasła](https://docs.aspose.com/slides/pl/cpp/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

### Jak „Read-Only recommended” różni się od pełnej ochrony hasłem?

„Read-Only recommended” wyświetla jedynie sugestię otwarcia pliku w trybie tylko do odczytu i jest łatwa do obejścia. [Ochrona hasłem](/slides/pl/cpp/password-protected-presentation/) faktycznie ogranicza otwieranie lub edycję i jest odpowiednia, gdy potrzebujesz rzeczywistych kontroli bezpieczeństwa.

### Czy „Read-Only recommended” można połączyć z znakami wodnymi, aby jeszcze bardziej zniechęcić do edycji?

Tak. Rekomendację można połączyć z [znakami wodnymi](/slides/pl/cpp/watermark/) jako wizualnym środkiem odstraszającym; są to odrębne mechanizmy i dobrze ze sobą współpracują.

### Czy makro lub zewnętrzne narzędzie może nadal modyfikować plik, gdy włączona jest rekomendacja?

Tak. Rekomendacja nie blokuje zmian programistycznych. Aby zapobiec automatycznym edycjom, użyj [haseł i szyfrowania](/slides/pl/cpp/password-protected-presentation/).

### Jak „Read-Only recommended” odnosi się do flag „is encrypted” i „is write protected”?

Są to różne sygnały. „Read-Only recommended” to miękka, opcjonalna podpowiedź; [get_IsWriteProtected](https://reference.aspose.com/slides/pl/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) i [get_IsEncrypted](https://reference.aspose.com/slides/pl/cpp/aspose.slides/protectionmanager/get_isencrypted/) wskazują rzeczywiste ograniczenia zapisu lub odczytu, które zależą od haseł lub szyfrowania.