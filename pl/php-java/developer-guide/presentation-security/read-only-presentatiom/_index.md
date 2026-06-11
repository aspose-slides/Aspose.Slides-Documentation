---
title: Zapisywanie prezentacji w trybie tylko do odczytu przy użyciu PHP
linktitle: Prezentacja tylko do odczytu
type: docs
weight: 30
url: /pl/php-java/read-only-presentation/
keywords:
- tylko do odczytu
- chronić prezentację
- zapobiegać edycji
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Ładuj i zapisuj pliki PowerPoint (PPT, PPTX) w trybie tylko do odczytu przy użyciu Aspose.Slides for PHP, zapewniając precyzyjne podglądy slajdów bez modyfikowania Twoich prezentacji."
---
## **Wprowadzenie**

W programie PowerPoint 2019 firma Microsoft wprowadziła ustawienie **Always Open Read-Only** jako jedną z opcji, których użytkownicy mogą używać do ochrony swoich prezentacji. Możesz chcieć użyć tego ustawienia Read-Only, aby chronić prezentację, gdy

- Chcesz zapobiec przypadkowym edycjom i zachować zawartość prezentacji w bezpiecznym stanie. 
- Chcesz ostrzec odbiorców, że dostarczona przez Ciebie prezentacja jest wersją ostateczną. 

Po wybraniu opcji **Always Open Read-Only** dla prezentacji, gdy użytkownicy otwierają prezentację, widzą rekomendację **Read-Only** i mogą zobaczyć komunikat w tej formie: *Aby zapobiec przypadkowym zmianom, autor ustawił ten plik do otwierania w trybie tylko do odczytu.*

Rekomendacja Read-Only jest prostą, ale skuteczną metodą odstraszania od edycji, ponieważ użytkownicy muszą wykonać pewne czynności, aby ją usunąć przed możliwością edycji prezentacji. Jeśli nie chcesz, aby użytkownicy wprowadzali zmiany w prezentacji i chcesz poinformować ich o tym w uprzejmy sposób, rekomendacja Read-Only może być dla Ciebie dobrą opcją. 

> Jeśli prezentacja z ochroną **Read-Only** zostanie otwarta w starszej wersji Microsoft PowerPoint — która nie obsługuje niedawno wprowadzonej funkcji — rekomendacja **Read-Only** zostanie zignorowana (prezentacja zostanie otwarta normalnie).

## **Zastosuj tryb Read-Only**

Aspose.Slides for PHP via Java umożliwia ustawienie prezentacji jako **Read-Only**, co oznacza, że użytkownicy (po otwarciu prezentacji) widzą rekomendację **Read-Only**. Ten przykładowy kod pokazuje, jak ustawić prezentację jako **Read-Only** przy użyciu Aspose.Slides:

```php
  $pres = new Presentation();
  try {
    $pres->getProtectionManager()->setReadOnlyRecommended(true);
    $pres->save("ReadOnlyPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

**Uwaga**: Rekomendacja **Read-Only** ma po prostu na celu zniechęcenie do edycji lub zapobieżenie przypadkowym zmianom w prezentacji PowerPoint. Jeśli zmotywowana osoba — która wie, co robi — zdecyduje się edytować Twoją prezentację, może łatwo usunąć ustawienie Read-Only. Jeśli naprawdę musisz zapobiec nieautoryzowanej edycji, lepiej jest używać [bardziej rygorystycznych zabezpieczeń obejmujących szyfrowanie i hasła](https://docs.aspose.com/slides/pl/php-java/password-protected-presentation/).

{{% /alert %}} 

## **FAQ**

**Czym różni się 'Read-Only recommended' od pełnej ochrony hasłem?**

'Read-Only recommended' wyświetla jedynie sugestię otwarcia pliku w trybie tylko do odczytu i łatwo ją obejść. [Ochrona hasłem](/slides/pl/php-java/password-protected-presentation/) faktycznie ogranicza otwieranie lub edycję i jest odpowiednia, gdy potrzebujesz prawdziwych mechanizmów zabezpieczających.

**Czy 'Read-Only recommended' można połączyć z znakami wodnymi, aby jeszcze bardziej zniechęcić do edycji?**

Tak. Rekomendację można połączyć z [znakami wodnymi](/slides/pl/php-java/watermark/) jako wizualnym odstraszaczem; są to odrębne mechanizmy i dobrze ze sobą współdziałają.

**Czy makro lub zewnętrzne narzędzie nadal może modyfikować plik, gdy włączona jest rekomendacja?**

Tak. Rekomendacja nie blokuje zmian programowych. Aby zapobiec automatycznej edycji, użyj [haseł i szyfrowania](/slides/pl/php-java/password-protected-presentation/).

**Jak 'Read-Only recommended' odnosi się do metod 'isEncrypted' i 'isWriteProtected'?**

To różne sygnały. 'Read-Only recommended' to miękka, opcjonalna podpowiedź; [isWriteProtected](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/iswriteprotected/) i [isEncrypted](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/isencrypted/) wskazują rzeczywiste ograniczenia zapisu lub odczytu, które zależą od haseł lub szyfrowania.