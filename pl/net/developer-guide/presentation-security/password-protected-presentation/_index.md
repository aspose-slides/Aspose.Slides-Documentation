---
title: Zabezpiecz prezentacje hasłami w .NET
linktitle: Ochrona hasłem
type: docs
weight: 20
url: /pl/net/password-protected-presentation/
keywords:
- zablokuj PowerPoint
- zablokuj prezentację
- odblokuj PowerPoint
- odblokuj prezentację
- chron PowerPoint
- chron prezentację
- ustaw hasło
- dodaj hasło
- zaszyfruj PowerPoint
- zaszyfruj prezentację
- odszyfruj PowerPoint
- odszyfruj prezentację
- ochrona przed zapisem
- bezpieczeństwo PowerPoint
- bezpieczeństwo prezentacji
- usuń hasło
- usuń ochronę
- usuń szyfrowanie
- wyłącz hasło
- wyłącz ochronę
- usuń ochronę przed zapisem
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak łatwo blokować i odblokowywać prezentacje PowerPoint i OpenDocument zabezpieczone hasłem przy użyciu Aspose.Slides dla .NET. Zabezpiecz swoje prezentacje."
---
## **Wprowadzenie**

Kiedy zabezpieczasz prezentację hasłem, oznacza to, że ustawiasz hasło, które wymusza określone ograniczenia na prezentację. Aby usunąć te ograniczenia, należy wprowadzić hasło. Prezentacja zabezpieczona hasłem jest uważana za zablokowaną prezentację.

Typowo możesz ustawić hasło, aby wymusić te ograniczenia na prezentacji:

- **Modyfikacja**

  Jeśli chcesz, aby tylko wybrani użytkownicy mogli modyfikować Twoją prezentację, możesz ustawić ograniczenie modyfikacji. To ograniczenie uniemożliwia osobom modyfikowanie, zmienianie lub kopiowanie elementów w Twojej prezentacji, dopóki nie podadzą hasła. 

  Jednak nawet bez hasła użytkownik nadal będzie mógł uzyskać dostęp i otworzyć dokument. W trybie tylko do odczytu użytkownik może przeglądać zawartość — w tym hiperłącza, animacje, efekty i inne elementy — wewnątrz prezentacji, ale nie może kopiować elementów ani zapisywać prezentacji.

- **Otwieranie**

  Jeśli chcesz, aby tylko wybrani użytkownicy mogli otwierać Twoją prezentację, możesz ustawić ograniczenie otwierania. To ograniczenie uniemożliwia osobom nawet przeglądanie zawartości prezentacji, dopóki nie podadzą hasła.

  Technicznie ograniczenie otwierania również zapobiega modyfikacji prezentacji — jeśli ktoś nie może otworzyć prezentacji, nie może jej modyfikować ani wprowadzać zmian.

**Note:** Gdy zabezpieczasz prezentację hasłem, aby uniemożliwić otwarcie, plik prezentacji zostaje zaszyfrowany.

## **Ochrona hasłem w Aspose.Slides**

**Supported formats**

Aspose.Slides obsługuje ochronę hasłem, szyfrowanie i podobne operacje dla prezentacji w następujących formatach:

- PPTX i PPT – Microsoft PowerPoint Presentations
- ODP – OpenDocument Presentations
- OTP – OpenDocument Presentation Templates

**Supported operations**

Aspose.Slides pozwala używać ochrony hasłem na prezentacjach, aby zapobiegać modyfikacjom w następujący sposób:

- Szyfrowanie prezentacji
- Ustawianie ochrony przed zapisem na prezentacji

**Other operations**

Aspose.Slides umożliwia wykonywanie dodatkowych zadań związanych z ochroną hasłem i szyfrowaniem w następujący sposób:

- Odszyfrowywanie prezentacji; otwieranie zaszyfrowanej prezentacji
- Usuwanie szyfrowania; wyłączanie ochrony hasłem
- Usuwanie ochrony przed zapisem z prezentacji
- Pobieranie właściwości zaszyfrowanej prezentacji
- Sprawdzanie, czy prezentacja jest zabezpieczona hasłem przed jej załadowaniem
- Sprawdzanie, czy prezentacja jest zaszyfrowana
- Sprawdzanie, czy prezentacja jest zabezpieczona hasłem

## **Zabezpiecz prezentację hasłem**

Możesz zaszyfrować prezentację, ustawiając hasło. Następnie, aby zmodyfikować zablokowaną prezentację, użytkownik musi podać hasło.

Aby zaszyfrować (lub zabezpieczyć hasłem) prezentację, użyj metody `Encrypt` z [ProtectionManager](https://reference.aspose.com/slides/pl/net/aspose.slides/protectionmanager). Przekaż hasło do metody `Encrypt`, a następnie użyj metody `Save`, aby zapisać teraz zaszyfrowaną prezentację.

Ten przykładowy kod pokazuje, jak zaszyfrować prezentację:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Ustaw ochronę przed zapisem na prezentacji** 

Możesz dodać znacznik „Do not modify” do prezentacji. Informuje to użytkowników, że nie chcesz, aby wprowadzali zmiany w prezentacji.

**Note:** Proces ochrony przed zapisem nie szyfruje prezentacji. Dlatego użytkownicy — jeśli zechcą — mogą modyfikować prezentację, ale aby zapisać zmiany, będą musieli zapisać ją pod inną nazwą.

Aby ustawić ochronę przed zapisem, użyj metody `SetWriteProtection`. Ten przykładowy kod pokazuje, jak ustawić ochronę przed zapisem na prezentacji:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Załaduj zaszyfrowaną prezentację**

Aspose.Slides pozwala załadować zaszyfrowaną prezentację, podając prawidłowe hasło. Ten przykładowy kod pokazuje, jak załadować zaszyfrowaną prezentację:

```c#
using Aspose.Slides;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Pracuj z odszyfrowaną prezentacją.
}
```

## **Usuń szyfrowanie z prezentacji**

Możesz usunąć szyfrowanie lub ochronę hasłem z prezentacji, umożliwiając użytkownikom dostęp lub modyfikację bez ograniczeń.

Aby usunąć szyfrowanie lub ochronę hasłem, wywołaj metodę [RemoveEncryption](https://reference.aspose.com/slides/pl/net/aspose.slides/protectionmanager/methods/removeencryption). Ten przykładowy kod pokazuje, jak usunąć szyfrowanie z prezentacji:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Usuń ochronę przed zapisem z prezentacji**

Możesz użyć Aspose.Slides, aby usunąć ochronę przed zapisem z pliku prezentacji. Dzięki temu użytkownicy mogą modyfikować ją dowolnie — i nie otrzymają żadnych ostrzeżeń podczas takich operacji.

Usunięcie ochrony przed zapisem odbywa się przy użyciu metody [RemoveWriteProtection](https://reference.aspose.com/slides/pl/net/aspose.slides/protectionmanager/methods/removewriteprotection). Ten przykładowy kod pokazuje, jak usunąć ochronę przed zapisem z prezentacji:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Pobierz właściwości zaszyfrowanej prezentacji**

Typowo użytkownicy mają trudności z pobraniem właściwości dokumentu zaszyfrowanej lub zabezpieczonej hasłem prezentacji. Aspose.Slides oferuje mechanizm, który pozwala zabezpieczyć prezentację hasłem, jednocześnie zachowując możliwość dostępu do jej właściwości.

**Note:** Domyślnie, gdy Aspose.Slides szyfruje prezentację, właściwości dokumentu prezentacji również są zabezpieczone hasłem. Jeśli potrzebujesz, aby właściwości dokumentu były dostępne nawet po szyfrowaniu, Aspose.Slides umożliwia dokładnie to.

Jeśli chcesz, aby użytkownicy zachowali możliwość dostępu do właściwości zaszyfrowanej prezentacji, ustaw właściwość `EncryptDocumentProperties` interfejsu [IProtectionManager](https://reference.aspose.com/slides/pl/net/aspose.slides/iprotectionmanager/) na `false`. Ten przykładowy kod pokazuje, jak zaszyfrować prezentację, pozostawiając jednocześnie dostęp do jej właściwości dokumentu:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Załaduj tylko właściwości dokumentu z zaszyfrowanej prezentacji**

Aby sprawdzić metadane zaszyfrowanej prezentacji bez ładowania jej slajdów ani innej zawartości, utwórz obiekt [LoadOptions](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/) i ustaw [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) na `true`. W tym trybie Aspose.Slides ignoruje hasło i ładuje wyłącznie właściwości dokumentu, które są publicznie dostępne.

Poniższy przykład kodu odczytuje wbudowane i niestandardowe właściwości dokumentu poprzez [IPresentation.DocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/documentproperties/):

```c#
using Aspose.Slides;

var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// Odczytaj wbudowane właściwości dokumentu.
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// Odczytaj niestandardowe właściwości dokumentu.
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

Ten przepływ pracy działa tylko wtedy, gdy właściwości dokumentu pozostały niezaszyfrowane (publiczne) w momencie szyfrowania prezentacji. Jeśli właściwości dokumentu są zaszyfrowane, ustawienie `OnlyLoadDocumentProperties` na `true` spowoduje wyjątek, ponieważ w tym trybie hasło jest ignorowane. Aby uzyskać dostęp do zaszyfrowanych właściwości dokumentu lub załadować pełną prezentację, w tym slajdy i inną zawartość, podaj prawidłową wartość `Password` w [LoadOptions](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/).

## **Sprawdź, czy prezentacja jest zabezpieczona hasłem**

Przed załadowaniem prezentacji możesz chcieć sprawdzić, czy nie została zabezpieczona hasłem. Pomaga to uniknąć błędów i podobnych problemów, które pojawiają się, gdy prezentacja zabezpieczona hasłem jest ładowana bez właściwego hasła.

Ten kod C# pokazuje, jak zbadać prezentację pod kątem ochrony hasłem, nie ładując jej w pełni:

```c#
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Sprawdź, czy prezentacja jest zaszyfrowana**

Aspose.Slides umożliwia sprawdzenie, czy prezentacja jest zaszyfrowana. W tym celu możesz użyć właściwości [IsEncrypted](https://reference.aspose.com/slides/pl/net/aspose.slides/protectionmanager/properties/isencrypted), która zwraca `true`, jeśli prezentacja jest zaszyfrowana, lub `false`, jeśli nie jest.

Ten przykładowy kod pokazuje, jak sprawdzić, czy prezentacja jest zaszyfrowana:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Sprawdź, czy prezentacja jest chroniona przed zapisem**

Aspose.Slides umożliwia sprawdzenie, czy prezentacja jest chroniona przed zapisem. W tym celu możesz użyć właściwości [IsWriteProtected](https://reference.aspose.com/slides/pl/net/aspose.slides/protectionmanager/properties/iswriteprotected), która zwraca `true`, jeśli prezentacja jest chroniona przed zapisem, lub `false`, jeśli nie jest.

Ten przykładowy kod pokazuje, jak sprawdzić, czy prezentacja jest chroniona przed zapisem:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Zweryfikuj użycie hasła w prezentacji**

Możesz chcieć sprawdzić i potwierdzić, że konkretne hasło zostało użyte do zabezpieczenia dokumentu prezentacji. Aspose.Slides zapewnia środki do weryfikacji hasła.

Ten przykładowy kod pokazuje, jak zweryfikować hasło:

```c#
using Aspose.Slides;

using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Sprawdź, czy hasło się zgadza.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Zwraca on `true`, jeśli prezentacja została zaszyfrowana podanym hasłem; w przeciwnym razie zwraca `false`.

{{% alert color="info" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/pl/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Zabezpiecz prezentację hasłem online**

1. Przejdź do naszej strony [**Aspose.Slides Lock**](https://products.aspose.app/slides/pl/lock).
1. Kliknij **Drop or upload your files**.
1. Wybierz plik, który chcesz zabezpieczyć hasłem, na swoim komputerze.
1. Wprowadź preferowane hasło do ochrony edycji oraz preferowane hasło do ochrony podglądu.
1. Jeśli chcesz, aby użytkownicy widzieli Twoją prezentację jako wersję finalną, zaznacz pole wyboru **Mark as final**.
1. Kliknij **PROTECT NOW.**
1. Kliknij **DOWNLOAD NOW.**

![Chronienie hasłem prezentacji PowerPoint](slides-lock.png)

## **FAQ**

**Jakie metody szyfrowania są obsługiwane przez Aspose.Slides?**

Aspose.Slides obsługuje nowoczesne metody szyfrowania, w tym algorytmy oparte na AES, zapewniając wysoki poziom bezpieczeństwa danych Twoich prezentacji.

**Co się stanie, jeśli podczas próby otwarcia prezentacji podane zostanie nieprawidłowe hasło?**

Zostanie zgłoszony wyjątek, informujący, że dostęp do prezentacji został odmówiony. Pomaga to zapobiegać nieautoryzowanemu dostępowi i chroni zawartość prezentacji.

**Czy istnieją jakiekolwiek skutki wydajnościowe przy pracy z prezentacjami zabezpieczonymi hasłem?**

Proces szyfrowania i odszyfrowywania może wprowadzić niewielkie opóźnienie podczas operacji otwierania i zapisywania. W większości przypadków wpływ ten jest minimalny i nie wpływa znacząco na ogólny czas przetwarzania zadań związanych z prezentacjami.