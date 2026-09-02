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
- chroń PowerPoint
- chroń prezentację
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
description: "Dowiedz się, jak w prosty sposób blokować i odblokowywać hasłowo zabezpieczone prezentacje PowerPoint i OpenDocument za pomocą Aspose.Slides dla .NET. Zabezpiecz swoje prezentacje."
---
## **Wprowadzenie**

Kiedy zabezpieczasz prezentację hasłem, oznacza to, że ustawiasz hasło, które narzuca określone ograniczenia na prezentację. Aby usunąć te ograniczenia, należy wprowadzić hasło. Prezentacja zabezpieczona hasłem jest uznawana za zablokowaną prezentację.

Zazwyczaj możesz ustawić hasło, aby wymusić te ograniczenia na prezentacji:

- **Modyfikacja**

Jeśli chcesz, aby tylko określone osoby mogły modyfikować twoją prezentację, możesz ustawić ograniczenie modyfikacji. To ograniczenie uniemożliwia ludziom modyfikowanie, zmienianie lub kopiowanie elementów w twojej prezentacji, chyba że podadzą hasło.  

Jednakże, nawet bez hasła, użytkownik nadal będzie mógł uzyskać dostęp i otworzyć twój dokument. W tym trybie tylko do odczytu użytkownik może przeglądać zawartość — w tym hiperlinki, animacje, efekty i inne elementy — w twojej prezentacji, ale nie może kopiować elementów ani zapisywać prezentacji.

- **Otwieranie**

Jeśli chcesz, aby tylko określone osoby mogły otworzyć twoją prezentację, możesz ustawić ograniczenie otwierania. To ograniczenie uniemożliwia ludziom nawet przeglądanie zawartości prezentacji, chyba że podadzą hasło.  

Technicznie, ograniczenie otwierania także uniemożliwia użytkownikom modyfikowanie prezentacji — jeśli osoby nie mogą otworzyć prezentacji, nie mogą jej modyfikować ani wprowadzać zmian do niej.

**Uwaga:** Kiedy zabezpieczasz prezentację hasłem, aby uniemożliwić jej otwarcie, plik prezentacji zostaje zaszyfrowany.

## **Zabezpieczenie hasłem w Aspose.Slides**

**Obsługiwane formaty**

Aspose.Slides obsługuje zabezpieczenie hasłem, szyfrowanie i podobne operacje dla prezentacji w tych formatach:

- PPTX i PPT – Prezentacje Microsoft PowerPoint
- ODP – Prezentacje OpenDocument
- OTP – Szablony prezentacji OpenDocument

**Obsługiwane operacje**

Aspose.Slides umożliwia użycie zabezpieczenia hasłem w prezentacjach, aby zapobiec modyfikacjom w następujący sposób:

- Szyfrowanie prezentacji
- Ustawianie ochrony przed zapisem w prezentacji

**Inne operacje**

Aspose.Slides umożliwia wykonywanie dodatkowych zadań związanych z zabezpieczeniem hasłem i szyfrowaniem w następujący sposób:

- Deszyfrowanie prezentacji; otwieranie zaszyfrowanej prezentacji
- Usuwanie szyfrowania; wyłączanie zabezpieczenia hasłem
- Usuwanie ochrony przed zapisem z prezentacji
- Pobieranie właściwości zaszyfrowanej prezentacji
- Sprawdzanie, czy prezentacja jest zabezpieczona hasłem przed jej wczytaniem
- Sprawdzanie, czy prezentacja jest zaszyfrowana
- Sprawdzanie, czy prezentacja jest zabezpieczona hasłem

## **Zabezpiecz prezentację hasłem**

Możesz zaszyfrować prezentację, ustawiając hasło. Następnie, aby zmodyfikować zablokowaną prezentację, użytkownik musi podać hasło.

Aby zaszyfrować (lub zabezpieczyć hasłem) prezentację, użyj metody `Encrypt` z [ProtectionManager](https://reference.aspose.com/slides/pl/net/aspose.slides/protectionmanager) aby ustawić hasło. Przekaż hasło do metody `Encrypt`, a potem użyj metody `Save`, aby zapisać teraz zaszyfrowaną prezentację.

Ten przykładowy kod pokazuje, jak zaszyfrować prezentację:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Ustaw ochronę przed zapisem w prezentacji** 

Możesz dodać znacznik informujący „Nie modyfikować” do prezentacji. To informuje użytkowników, że nie chcesz, aby wprowadzali zmiany w prezentacji.

**Uwaga:** Proces ochrony przed zapisem nie szyfruje prezentacji. Dlatego użytkownicy — jeśli zechcą — mogą modyfikować prezentację, ale aby zapisać zmiany, będą musieli zapisać ją pod inną nazwą.

Aby ustawić ochronę przed zapisem, użyj metody `SetWriteProtection`. Ten przykładowy kod pokazuje, jak ustawić ochronę przed zapisem w prezentacji:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Wczytaj zaszyfrowaną prezentację**

Aspose.Slides umożliwia wczytanie zaszyfrowanej prezentacji, podając prawidłowe hasło. Ten przykładowy kod pokazuje, jak wczytać zaszyfrowaną prezentację:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Pracuj z odszyfrowaną prezentacją.
}
```

## **Usuń szyfrowanie z prezentacji**

Możesz usunąć szyfrowanie lub zabezpieczenie hasłem z prezentacji, pozwalając użytkownikom na dostęp lub modyfikację bez ograniczeń.

Aby usunąć szyfrowanie lub zabezpieczenie hasłem, wywołaj metodę [RemoveEncryption](https://reference.aspose.com/slides/pl/net/aspose.slides/protectionmanager/methods/removeencryption). Ten przykładowy kod pokazuje, jak usunąć szyfrowanie z prezentacji:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Usuń ochronę przed zapisem z prezentacji**

Możesz użyć Aspose.Slides, aby usunąć ochronę przed zapisem z pliku prezentacji. W ten sposób użytkownicy mogą modyfikować ją dowolnie — i nie otrzymają żadnych ostrzeżeń podczas wykonywania takich czynności.

Możesz usunąć ochronę przed zapisem, używając metody [RemoveWriteProtection](https://reference.aspose.com/slides/pl/net/aspose.slides/protectionmanager/methods/removewriteprotection). Ten przykładowy kod pokazuje, jak usunąć ochronę przed zapisem z prezentacji:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Pobierz właściwości zaszyfrowanej prezentacji**

Zwykle użytkownicy mają trudności z pobraniem właściwości dokumentu zaszyfrowanej lub zabezpieczonej hasłem prezentacji. Jednak Aspose.Slides oferuje mechanizm, który pozwala zabezpieczyć prezentację hasłem, jednocześnie zachowując możliwość dostępu do jej właściwości.

**Uwaga:** Domyślnie, gdy Aspose.Slides szyfruje prezentację, właściwości dokumentu prezentacji są również zabezpieczone hasłem. Jeśli potrzebujesz, aby właściwości dokumentu były dostępne nawet po szyfrowaniu, Aspose.Slides umożliwia dokładnie to.

Jeśli chcesz, aby użytkownicy zachowali możliwość dostępu do właściwości zaszyfrowanej prezentacji, ustaw właściwość `EncryptDocumentProperties` interfejsu [IProtectionManager](https://reference.aspose.com/slides/pl/net/aspose.slides/iprotectionmanager/) na `false`. Ten przykładowy kod pokazuje, jak zaszyfrować prezentację, jednocześnie umożliwiając użytkownikom dostęp do jej właściwości dokumentu:

```c#
using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Wczytaj tylko właściwości dokumentu z zaszyfrowanej prezentacji**

Aby przejrzeć metadane zaszyfrowanej prezentacji bez wczytywania jej slajdów ani innej zawartości, utwórz obiekt [LoadOptions](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/) i ustaw [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) na `true`. W tym trybie Aspose.Slides ignoruje hasło i wczytuje tylko właściwości dokumentu, które są publicznie dostępne.

Poniższy przykład kodu odczytuje wbudowane i niestandardowe właściwości dokumentu za pomocą [IPresentation.DocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/documentproperties/):

```c#
var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// Read built-in document properties.
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// Read custom document properties.
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

Ten przepływ pracy działa tylko wtedy, gdy właściwości dokumentu zostały pozostawione niezaszyfrowane (publiczne) w momencie szyfrowania prezentacji. Jeśli właściwości dokumentu są zaszyfrowane, ustawienie `OnlyLoadDocumentProperties` na `true` powoduje wyjątek, ponieważ hasło jest ignorowane w tym trybie. Aby uzyskać dostęp do zaszyfrowanych właściwości dokumentu lub wczytać pełną prezentację, włącznie ze slajdami i inną zawartością, podaj prawidłową wartość `Password` w [LoadOptions](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/).

## **Sprawdź, czy prezentacja jest zabezpieczona hasłem**

Zanim wczytasz prezentację, możesz chcieć sprawdzić, czy nie została zabezpieczona hasłem. Pomaga to uniknąć błędów i podobnych problemów, które występują, gdy prezentacja zabezpieczona hasłem jest wczytywana bez właściwego hasła.

Ten kod C# pokazuje, jak sprawdzić prezentację pod kątem zabezpieczenia hasłem bez jej faktycznego wczytywania:

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Sprawdź, czy prezentacja jest zaszyfrowana**

Aspose.Slides umożliwia sprawdzenie, czy prezentacja jest zaszyfrowana. Do wykonania tego zadania możesz użyć właściwości [IsEncrypted](https://reference.aspose.com/slides/pl/net/aspose.slides/protectionmanager/properties/isencrypted), która zwraca `true`, jeśli prezentacja jest zaszyfrowana, lub `false`, jeśli nie jest.

Ten przykładowy kod pokazuje, jak sprawdzić, czy prezentacja jest zaszyfrowana:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Sprawdź, czy prezentacja jest chroniona przed zapisem**

Aspose.Slides umożliwia sprawdzenie, czy prezentacja jest chroniona przed zapisem. Do wykonania tego zadania możesz użyć właściwości [IsWriteProtected](https://reference.aspose.com/slides/pl/net/aspose.slides/protectionmanager/properties/iswriteprotected), która zwraca `true`, jeśli prezentacja jest chroniona przed zapisem, lub `false`, jeśli nie jest.

Ten przykładowy kod pokazuje, jak sprawdzić, czy prezentacja jest chroniona przed zapisem:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Zweryfikuj użycie hasła w prezentacji**

Możesz chcieć sprawdzić i potwierdzić, że określone hasło zostało użyte do zabezpieczenia dokumentu prezentacji. Aspose.Slides zapewnia możliwość weryfikacji hasła.

Ten przykładowy kod pokazuje, jak zweryfikować hasło:

```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Sprawdź, czy hasło jest zgodne.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Zwraca `true`, jeśli prezentacja została zaszyfrowana podanym hasłem; w przeciwnym razie zwraca `false`.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/pl/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Zabezpiecz prezentację hasłem online**

1. Przejdź do naszej strony [**Aspose.Slides Lock**](https://products.aspose.app/slides/pl/lock). 
2. Kliknij **Drop or upload your files**. 
3. Wybierz plik, który chcesz zabezpieczyć hasłem, na swoim komputerze. 
4. Wprowadź preferowane hasło do ochrony edycji oraz preferowane hasło do ochrony podglądu. 
5. Jeśli chcesz, aby użytkownicy widzieli twoją prezentację jako ostateczną kopię, zaznacz pole wyboru **Mark as final**. 
6. Kliknij **PROTECT NOW.** 
7. Kliknij **DOWNLOAD NOW.**

![Password protect PowerPoint presentations](slides-lock.png)

## **FAQ**

**Jakie metody szyfrowania są obsługiwane przez Aspose.Slides?**

Aspose.Slides obsługuje nowoczesne metody szyfrowania, w tym algorytmy oparte na AES, zapewniając wysoki poziom bezpieczeństwa danych Twoich prezentacji.

**Co się dzieje, gdy wprowadzono nieprawidłowe hasło przy próbie otwarcia prezentacji?**

Zostaje rzucony wyjątek, jeśli użyto nieprawidłowego hasła, informując, że dostęp do prezentacji jest odrzucony. Pomaga to zapobiec nieautoryzowanemu dostępowi i chroni zawartość prezentacji.

**Czy istnieją jakiekolwiek wpływy na wydajność przy pracy z prezentacjami zabezpieczonymi hasłem?**

Proces szyfrowania i deszyfrowania może wprowadzić niewielkie obciążenie podczas operacji otwierania i zapisu. W większości przypadków wpływ na wydajność jest minimalny i nie wpływa znacząco na ogólny czas przetwarzania zadań związanych z prezentacjami.