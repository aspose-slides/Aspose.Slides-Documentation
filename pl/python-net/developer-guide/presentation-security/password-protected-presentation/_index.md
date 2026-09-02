---
title: Zabezpiecz prezentacje hasłami przy użyciu Pythona
linktitle: Ochrona hasłem
type: docs
weight: 20
url: /pl/python-net/password-protected-presentation/
keywords:
- zablokuj PowerPoint
- zablokuj prezentację
- odblokuj PowerPoint
- odblokuj prezentację
- zabezpiecz PowerPoint
- zabezpiecz prezentację
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
- prezentacja PowerPoint
- Python
- Aspose.Slides
description: "Dowiedz się, jak łatwo blokować i odblokowywać prezentacje PowerPoint i OpenDocument zabezpieczone hasłem przy użyciu Aspose.Slides dla Pythona w środowisku .NET. Zwiększ swoją wydajność i zabezpiecz prezentacje dzięki naszemu przewodnikowi krok po kroku."
---
## **Wprowadzenie**

Kiedy zabezpieczasz prezentację hasłem, oznacza to ustawienie hasła, które narzuca określone ograniczenia na prezentację. Aby usunąć ograniczenia, należy wprowadzić hasło. Prezentacja zabezpieczona hasłem jest traktowana jako zablokowana prezentacja.

Zazwyczaj możesz ustawić hasło, aby wymusić te ograniczenia na prezentacji:

- **Modyfikacja**

  Jeśli chcesz, aby tylko określeni użytkownicy mogli modyfikować Twoją prezentację, możesz ustawić ograniczenie modyfikacji. Ograniczenie to zapobiega osobom modyfikowanie, zmienianie lub kopiowanie elementów w Twojej prezentacji (chyba że podadzą hasło).  

  Jednak w tym przypadku, nawet bez hasła, użytkownik będzie mógł uzyskać dostęp do dokumentu i go otworzyć. W trybie tylko do odczytu użytkownik może przeglądać zawartość lub elementy — hiperłącza, animacje, efekty i inne — w prezentacji, ale nie może kopiować elementów ani zapisywać prezentacji.

- **Otwieranie**

  Jeśli chcesz, aby tylko określeni użytkownicy mogli otworzyć Twoją prezentację, możesz ustawić ograniczenie otwierania. Ograniczenie to zapobiega osobom nawet przeglądaniu zawartości Twojej prezentacji (chyba że podadzą hasło).

  Technicznie, ograniczenie otwierania również uniemożliwia użytkownikom modyfikowanie Twoich prezentacji: gdy ludzie nie mogą otworzyć prezentacji, nie mogą jej modyfikować ani wprowadzać zmian.  

  **Uwaga** że gdy zabezpieczasz prezentację hasłem, aby uniemożliwić jej otwieranie, plik prezentacji zostaje zaszyfrowany.

## Jak zabezpieczyć prezentację hasłem online

1. Przejdź do naszej strony [**Aspose.Slides Lock**](https://products.aspose.app/slides/pl/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Kliknij **Upuść lub prześlij pliki**.

3. Wybierz plik, który chcesz zabezpieczyć hasłem, na swoim komputerze.

4. Wprowadź preferowane hasło do ochrony przed edycją; Wprowadź preferowane hasło do ochrony przed przeglądaniem.

5. Jeśli chcesz, aby użytkownicy widzieli Twoją prezentację jako ostateczną kopię, zaznacz pole wyboru **Mark as final**.

6. Kliknij **PROTECT NOW.**

7. Kliknij **DOWNLOAD NOW.**

## **Ochrona hasłem prezentacji w Aspose.Slides**
**Obsługiwane formaty**

Aspose.Slides obsługuje ochronę hasłem, szyfrowanie i podobne operacje dla prezentacji w następujących formatach:

- PPTX i PPT - Microsoft PowerPoint Presentation
- ODP - OpenDocument Presentation
- OTP -  OpenDocument Presentation Template

**Obsługiwane operacje**

Aspose.Slides umożliwia użycie ochrony hasłem na prezentacjach w celu zapobiegania modyfikacjom w następujący sposób:

- Szyfrowanie prezentacji
- Ustawianie ochrony przed zapisem w prezentacji

**Inne operacje**

Aspose.Slides umożliwia wykonanie innych zadań związanych z ochroną hasłem i szyfrowaniem w następujący sposób:

- Odszyfrowywanie prezentacji; otwieranie zaszyfrowanej prezentacji
- Usuwanie szyfrowania; wyłączanie ochrony hasłem
- Usuwanie ochrony przed zapisem z prezentacji
- Pobieranie właściwości zaszyfrowanej prezentacji
- Sprawdzanie, czy prezentacja jest zaszyfrowana
- Sprawdzanie, czy prezentacja jest zabezpieczona hasłem.

## **Szyfrowanie prezentacji**

Możesz zaszyfrować prezentację, ustawiając hasło. Następnie, aby zmodyfikować zablokowaną prezentację, użytkownik musi podać hasło.

Aby zaszyfrować lub zabezpieczyć prezentację hasłem, musisz użyć metody encrypt (z [ProtectionManager](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/)), aby ustawić hasło dla prezentacji. Przekazujesz hasło do metody encrypt i używasz metody save, aby zapisać teraz zaszyfrowaną prezentację.

Ten przykładowy kod pokazuje, jak zaszyfrować prezentację:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustawianie ochrony przed zapisem w prezentacji** 

Możesz dodać do prezentacji znacznik z napisem „Do not modify”. Dzięki temu informujesz użytkowników, że nie chcesz, aby wprowadzali zmiany w prezentacji.  

**Uwaga**, proces ochrony przed zapisem nie szyfruje prezentacji. Dlatego użytkownicy — jeśli naprawdę tego chcą — mogą modyfikować prezentację, ale aby zapisać zmiany, będą musieli utworzyć prezentację pod inną nazwą. 

Aby ustawić ochronę przed zapisem, musisz użyć metody setWriteProtection. Ten przykładowy kod pokazuje, jak ustawić ochronę przed zapisem w prezentacji:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Odszyfrowywanie prezentacji; otwieranie zaszyfrowanej prezentacji**

Aspose.Slides umożliwia załadowanie zaszyfrowanego pliku, podając jego hasło. Aby odszyfrować prezentację, musisz wywołać metodę [remove_encryption](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/) bez parametrów. Następnie będziesz musiał wprowadzić prawidłowe hasło, aby wczytać prezentację.

Ten przykładowy kod pokazuje, jak odszyfrować prezentację: 

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **Usuwanie szyfrowania; wyłączanie ochrony hasłem**

Możesz usunąć szyfrowanie lub ochronę hasłem z prezentacji. W ten sposób użytkownicy będą mogli uzyskać dostęp do prezentacji i modyfikować ją bez ograniczeń. 

Aby usunąć szyfrowanie lub ochronę hasłem, musisz wywołać metodę [remove_encryption](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/). Ten przykładowy kod pokazuje, jak usunąć szyfrowanie z prezentacji:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Usuwanie ochrony przed zapisem z prezentacji**

Możesz użyć Aspose.Slides do usunięcia ochrony przed zapisem zastosowanej w pliku prezentacji. W ten sposób użytkownicy mogą modyfikować ją jak chcą — i nie otrzymują ostrzeżeń przy wykonywaniu takich czynności.

Możesz usunąć ochronę przed zapisem z prezentacji, używając metody [remove_write_protection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/). Ten przykładowy kod pokazuje, jak usunąć ochronę przed zapisem z prezentacji:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Pobieranie właściwości zaszyfrowanej prezentacji**

Zazwyczaj użytkownicy mają problem z pobraniem właściwości dokumentu zaszyfrowanej lub zabezpieczonej hasłem prezentacji. Jednak Aspose.Slides oferuje mechanizm, który pozwala zabezpieczyć prezentację hasłem, jednocześnie zachowując możliwość dostępu do jej właściwości.

**Uwaga:** Domyślnie, gdy Aspose.Slides szyfruje prezentację, właściwości dokumentu prezentacji również są chronione hasłem. Jeśli potrzebujesz, aby właściwości dokumentu były dostępne nawet po szyfrowaniu, Aspose.Slides umożliwia dokładnie to.

Jeśli chcesz, aby użytkownicy zachowali możliwość dostępu do właściwości zaszyfrowanej prezentacji, ustaw właściwość `encrypt_document_properties` obiektu [ProtectionManager](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/) na `False`. Ten przykładowy kod pokazuje, jak szyfrować prezentację, jednocześnie udostępniając użytkownikom dostęp do jej właściwości dokumentu:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("123123")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Wczytywanie tylko właściwości dokumentu z zaszyfrowanej prezentacji**

Aby przejrzeć metadane zaszyfrowanej prezentacji bez wczytywania jej slajdów ani innej zawartości, utwórz obiekt [LoadOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/) i ustaw [only_load_document_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/only_load_document_properties/) na `True`. W tym trybie Aspose.Slides ignoruje hasło i wczytuje tylko właściwości dokumentu, które są publicznie dostępne.

Poniższy przykład kodu odczytuje wbudowane właściwości dokumentu i wymienia własne właściwości dokumentu za pośrednictwem [Presentation.document_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/document_properties/):

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    document_properties = presentation.document_properties

    # Odczytaj wbudowane właściwości dokumentu.
    print("Title: " + document_properties.title)
    print("Author: " + document_properties.author)

    # Wypisz własne właściwości dokumentu.
    custom_property_count = document_properties.count_of_custom_properties

    for property_index in range(custom_property_count):
        property_name = document_properties.get_custom_property_name(property_index)
        print(property_name)
```

Ten przepływ pracy działa tylko wtedy, gdy właściwości dokumentu pozostały niezaszyfrowane (publiczne) w momencie szyfrowania prezentacji. Jeśli właściwości dokumentu są zaszyfrowane, ustawienie `only_load_document_properties` na `True` powoduje wyjątek, ponieważ w tym trybie hasło jest ignorowane. Aby uzyskać dostęp do zaszyfrowanych właściwości dokumentu lub wczytać pełną prezentację, w tym jej slajdy i inną zawartość, podaj prawidłową wartość `password` w [LoadOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/).

## **Sprawdzanie, czy prezentacja jest zabezpieczona hasłem przed jej wczytaniem**

Zanim wczytasz prezentację, możesz chcieć sprawdzić i potwierdzić, że prezentacja nie jest zabezpieczona hasłem. W ten sposób unikasz błędów i podobnych problemów, które pojawiają się, gdy zabezpieczona hasłem prezentacja jest wczytywana bez podania hasła.

Ten kod w Pythonie pokazuje, jak zbadać prezentację, aby sprawdzić, czy jest zabezpieczona hasłem (bez wczytywania samej prezentacji):

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **Sprawdzanie, czy prezentacja jest zaszyfrowana**

Aspose.Slides umożliwia sprawdzenie, czy prezentacja jest zaszyfrowana. Aby wykonać to zadanie, możesz użyć właściwości [is_encrypted](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/), która zwraca `True`, jeśli prezentacja jest zaszyfrowana, lub `False`, jeśli nie jest zaszyfrowana.

Ten przykładowy kod pokazuje, jak sprawdzić, czy prezentacja jest zaszyfrowana:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **Sprawdzanie, czy prezentacja jest zabezpieczona przed zapisem**

Aspose.Slides umożliwia sprawdzenie, czy prezentacja jest zabezpieczona przed zapisem. Aby wykonać to zadanie, możesz użyć właściwości [is_write_protected](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/), która zwraca `True`, jeśli prezentacja jest zabezpieczona przed zapisem, lub `False`, jeśli nie jest.

Ten przykładowy kod pokazuje, jak sprawdzić, czy prezentacja jest zabezpieczona przed zapisem:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **Walidacja lub potwierdzenie, że określone hasło zostało użyte do zabezpieczenia prezentacji**

Możesz chcieć sprawdzić i potwierdzić, że określone hasło zostało użyte do zabezpieczenia dokumentu prezentacji. Aspose.Slides zapewnia możliwość walidacji hasła.

Ten przykładowy kod pokazuje, jak zweryfikować hasło:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # sprawdź, czy "pass" jest dopasowane do
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

Zwraca `True`, jeśli prezentacja została zaszyfrowana podanym hasłem. W przeciwnym razie zwraca `False`.

{{% alert color="primary" title="Zobacz także" %}} 
- [Podpis cyfrowy w PowerPoint](/slides/pl/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Jakie metody szyfrowania są obsługiwane przez Aspose.Slides?**

Aspose.Slides obsługuje nowoczesne metody szyfrowania, w tym algorytmy oparte na AES, zapewniając wysoki poziom bezpieczeństwa danych w Twoich prezentacjach.

**Co się stanie, jeśli podczas próby otwarcia prezentacji zostanie wprowadzone nieprawidłowe hasło?**

Jeśli użyte zostanie nieprawidłowe hasło, zostaje zgłoszony wyjątek, informując, że dostęp do prezentacji został odrzucony. Pomaga to zapobiec nieautoryzowanemu dostępowi i chroni zawartość prezentacji.

**Czy istnieją jakiekolwiek skutki wydajnościowe przy pracy z zabezpieczonymi hasłem prezentacjami?**

Proces szyfrowania i odszyfrowywania może wprowadzić niewielki narzut podczas operacji otwierania i zapisywania. W większości przypadków wpływ na wydajność jest minimalny i nie ma istotnego wpływu na ogólny czas przetwarzania zadań związanych z prezentacjami.