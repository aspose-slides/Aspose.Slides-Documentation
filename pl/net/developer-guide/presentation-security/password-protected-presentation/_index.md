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
- ochroń PowerPoint
- ochroń prezentację
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
description: "Dowiedz się, jak łatwo blokować i odblokowywać prezentacje PowerPoint oraz OpenDocument zabezpieczone hasłem przy użyciu Aspose.Slides dla .NET. Zabezpiecz swoje prezentacje."
---
## **Wprowadzenie**

Gdy zabezpieczasz prezentację hasłem, ustawiasz hasło, które narzuca określone ograniczenia na prezentację. Aby usunąć te ograniczenia, należy wprowadzić hasło. Prezentacja zabezpieczona hasłem jest uważana za zablokowaną prezentację.

Zazwyczaj możesz ustawić hasło, aby wymusić te ograniczenia na prezentacji:

- **Modyfikacja**

Jeśli chcesz, aby tylko wybrani użytkownicy mogli modyfikować Twoją prezentację, możesz ustawić ograniczenie modyfikacji. To ograniczenie uniemożliwia osobom modyfikowanie, zmianę lub kopiowanie elementów w prezentacji, chyba że podadzą hasło.

Jednak nawet bez hasła użytkownik nadal będzie mógł uzyskać dostęp i otworzyć dokument. W trybie tylko do odczytu użytkownik może przeglądać zawartość — w tym hiperłącza, animacje, efekty i inne elementy — wewnątrz prezentacji, ale nie może kopiować elementów ani zapisać prezentacji.

- **Otwieranie**

Jeśli chcesz, aby tylko wybrani użytkownicy mogli otwierać Twoją prezentację, możesz ustawić ograniczenie otwierania. To ograniczenie uniemożliwia osobom nawet podgląd zawartości prezentacji, chyba że podadzą hasło.

Technicznie ograniczenie otwierania zapobiega również modyfikacji prezentacji — jeśli ludzie nie mogą otworzyć prezentacji, nie mogą jej modyfikować ani wprowadzać zmian.

**Uwaga:** Gdy zabezpieczasz prezentację hasłem przed otwarciem, plik prezentacji zostaje zaszyfrowany.

## **Zabezpieczanie hasłem w Aspose.Slides**

**Obsługiwane formaty**

Aspose.Slides obsługuje zabezpieczanie hasłem, szyfrowanie i podobne operacje dla prezentacji w następujących formatach:

- PPTX i PPT – prezentacje Microsoft PowerPoint  
- ODP – prezentacje OpenDocument  
- OTP – szablony prezentacji OpenDocument  

**Obsługiwane operacje**

Aspose.Slides umożliwia użycie zabezpieczenia hasłem w prezentacjach, aby zapobiec modyfikacjom na następujące sposoby:

- Szyfrowanie prezentacji  
- Ustawianie ochrony przed zapisem w prezentacji  

**Inne operacje**

Aspose.Slides pozwala wykonać dodatkowe zadania związane z zabezpieczeniem hasłem i szyfrowaniem w następujący sposób:

- odszyfrowywanie prezentacji; otwieranie zaszyfrowanej prezentacji  
- usuwanie szyfrowania; wyłączanie zabezpieczenia hasłem  
- usuwanie ochrony przed zapisem z prezentacji  
- pobieranie właściwości zaszyfrowanej prezentacji  
- sprawdzanie, czy prezentacja jest zabezpieczona hasłem przed jej załadowaniem  
- sprawdzanie, czy prezentacja jest zaszyfrowana  
- sprawdzanie, czy prezentacja jest zabezpieczona hasłem  

## **Zabezpieczenie prezentacji hasłem**

Możesz zaszyfrować prezentację, ustawiając hasło. Następnie, aby zmodyfikować zablokowaną prezentację, użytkownik musi podać hasło.

Aby zaszyfrować (lub zabezpieczyć hasłem) prezentację, użyj metody `Encrypt` z [ProtectionManager](https://reference.aspose.com/slides/pl/net/aspose.slides/protectionmanager), aby ustawić hasło. Przekaż hasło do metody `Encrypt`, a następnie użyj metody `Save`, aby zapisać teraz zaszyfrowaną prezentację.

Ten przykładowy kod pokazuje, jak zaszyfrować prezentację:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Ustawienie ochrony przed zapisem w prezentacji** 

Możesz dodać znacznik „Nie modyfikować” do prezentacji. Informuje to użytkowników, że nie chcesz, aby wprowadzali zmiany w prezentacji.

**Uwaga:** Proces ochrony przed zapisem nie szyfruje prezentacji. Dlatego użytkownicy — jeśli zechcą — mogą modyfikować prezentację, ale aby zapisać zmiany, będą musieli zapisać ją pod inną nazwą.

Aby ustawić ochronę przed zapisem, użyj metody `SetWriteProtection`. Ten przykładowy kod pokazuje, jak ustawić ochronę przed zapisem w prezentacji:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Ładowanie zaszyfrowanej prezentacji**

Aspose.Slides umożliwia ładowanie zaszyfrowanej prezentacji po przekazaniu właściwego hasła. Ten przykładowy kod pokazuje, jak załadować zaszyfrowaną prezentację:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Pracuj z odszyfrowaną prezentacją.
}
```

## **Usuwanie szyfrowania z prezentacji**

Możesz usunąć szyfrowanie lub zabezpieczenie hasłem z prezentacji, umożliwiając użytkownikom dostęp lub modyfikację bez ograniczeń.

Aby usunąć szyfrowanie lub zabezpieczenie hasłem, wywołaj metodę [RemoveEncryption](https://reference.aspose.com/slides/pl/net/aspose.slides/protectionmanager/methods/removeencryption). Ten przykładowy kod pokazuje, jak usunąć szyfrowanie z prezentacji:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Usuwanie ochrony przed zapisem z prezentacji**

Możesz użyć Aspose.Slides, aby usunąć ochronę przed zapisem z pliku prezentacji. Dzięki temu użytkownicy mogą modyfikować ją dowolnie — i nie otrzymają żadnych ostrzeżeń podczas wykonywania takich czynności.

Ochronę przed zapisem możesz usunąć, używając metody [RemoveWriteProtection](https://reference.aspose.com/slides/pl/net/aspose.slides/protectionmanager/methods/removewriteprotection). Ten przykładowy kod pokazuje, jak usunąć ochronę przed zapisem z prezentacji:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Pobieranie właściwości zaszyfrowanej prezentacji**

Typowo użytkownicy mają trudności z pobraniem właściwości dokumentu zaszyfrowanej lub zabezpieczonej hasłem prezentacji. Aspose.Slides oferuje mechanizm, który umożliwia zabezpieczenie prezentacji hasłem przy jednoczesnym zachowaniu możliwości uzyskania dostępu do jej właściwości.

**Uwaga:** Domyślnie, gdy Aspose.Slides szyfruje prezentację, właściwości dokumentu prezentacji również stają się zabezpieczone hasłem. Jeśli potrzebujesz, aby właściwości dokumentu były dostępne nawet po szyfrowaniu, Aspose.Slides pozwala to zrobić.

Jeśli chcesz, aby użytkownicy zachowali możliwość dostępu do właściwości zaszyfrowanej prezentacji, możesz ustawić właściwość [EncryptDocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/protectionmanager/properties/encryptdocumentproperties) na `true`. Ten przykładowy kod pokazuje, jak szyfrować prezentację, jednocześnie umożliwiając dostęp do jej właściwości dokumentu:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.EncryptDocumentProperties = true;
    presentation.ProtectionManager.Encrypt("123123");
}
```

## **Sprawdzanie, czy prezentacja jest zabezpieczona hasłem**

Przed załadowaniem prezentacji możesz chcieć sprawdzić, czy nie została zabezpieczona hasłem. To pomaga uniknąć błędów i podobnych problemów, które występują, gdy prezentacja zabezpieczona hasłem jest otwierana bez właściwego hasła.

Ten kod C# pokazuje, jak zbadać prezentację, aby sprawdzić, czy jest zabezpieczona hasłem, bez jej rzeczywistego ładowania:

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Sprawdzanie, czy prezentacja jest zaszyfrowana**

Aspose.Slides umożliwia sprawdzenie, czy prezentacja jest zaszyfrowana. W tym celu możesz użyć właściwości [IsEncrypted](https://reference.aspose.com/slides/pl/net/aspose.slides/protectionmanager/properties/isencrypted), która zwraca `true`, jeśli prezentacja jest zaszyfrowana, lub `false`, jeśli nie jest.

Ten przykładowy kod pokazuje, jak sprawdzić, czy prezentacja jest zaszyfrowana:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Sprawdzanie, czy prezentacja jest chroniona przed zapisem**

Aspose.Slides umożliwia sprawdzenie, czy prezentacja jest chroniona przed zapisem. W tym celu możesz użyć właściwości [IsWriteProtected](https://reference.aspose.com/slides/pl/net/aspose.slides/protectionmanager/properties/iswriteprotected), która zwraca `true`, jeśli prezentacja jest chroniona przed zapisem, lub `false`, jeśli nie jest.

Ten przykładowy kod pokazuje, jak sprawdzić, czy prezentacja jest chroniona przed zapisem:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Weryfikacja użycia hasła w prezentacji**

Możesz chcieć sprawdzić i potwierdzić, że określone hasło zostało użyte do zabezpieczenia dokumentu prezentacji. Aspose.Slides zapewnia środki do zweryfikowania hasła.

Ten przykładowy kod pokazuje, jak zweryfikować hasło:

```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Sprawdź, czy hasło jest prawidłowe.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Zwraca on `true`, jeśli prezentacja została zaszyfrowana podanym hasłem; w przeciwnym razie zwraca `false`.

{{% alert color="primary" title="Zobacz również" %}} 
- [Podpis cyfrowy w PowerPoint](/slides/pl/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Zabezpieczanie prezentacji hasłem online**

1. Przejdź do naszej strony [**Aspose.Slides Lock**](https://products.aspose.app/slides/pl/lock).  
1. Kliknij **Drop or upload your files**.  
1. Wybierz plik, który chcesz zabezpieczyć hasłem, na swoim komputerze.  
1. Wprowadź preferowane hasło do ochrony edycji oraz preferowane hasło do ochrony podglądu.  
1. Jeśli chcesz, aby użytkownicy widzieli Twoją prezentację jako wersję końcową, zaznacz pole wyboru **Mark as final**.  
1. Kliknij **PROTECT NOW.**  
1. Kliknij **DOWNLOAD NOW.**

![Password protect PowerPoint presentations](slides-lock.png)

## **FAQ**

**Jakie metody szyfrowania są obsługiwane przez Aspose.Slides?**

Aspose.Slides obsługuje nowoczesne metody szyfrowania, w tym algorytmy oparte na AES, zapewniając wysoki poziom bezpieczeństwa danych w Twoich prezentacjach.

**Co się stanie, jeśli wprowadzono niepoprawne hasło podczas próby otwarcia prezentacji?**

Wystąpi wyjątek, informujący, że dostęp do prezentacji został odrzucony. Pomaga to zapobiegać nieautoryzowanemu dostępowi i chroni zawartość prezentacji.

**Czy istnieją jakiekolwiek konsekwencje wydajnościowe przy pracy z prezentacjami zabezpieczonymi hasłem?**

Proces szyfrowania i odszyfrowywania może wprowadzić niewielkie opóźnienie podczas operacji otwierania i zapisywania. W większości przypadków wpływ na wydajność jest minimalny i nie wpływa znacząco na całkowity czas przetwarzania zadań związanych z prezentacjami.