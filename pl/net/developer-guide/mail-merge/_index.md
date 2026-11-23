---
title: Automatyzacja personalizacji prezentacji przy użyciu Mail Merge
linktitle: Mail Merge
type: docs
weight: 233
url: /pl/net/mail-merge/
keywords:
- Mail Merge
- personalizacja prezentacji
- szablon prezentacji
- znaczniki tekstowe
- źródło danych
- CSV
- Excel
- XLSX
- JSON
- XML
- scalanie danych
- generowanie prezentacji
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak używać Mail Merge w Aspose.Slides for .NET, aby wypełniać szablony prezentacji danymi oraz generować spersonalizowane prezentacje PowerPoint z źródeł CSV, Excel, JSON i XML."
---
## **Mail Merge w prezentacjach PowerPoint**

Aspose.Slides for .NET umożliwia automatyczne generowanie prezentacji PowerPoint przy użyciu szablonu i źródła danych. Mail Merge wypełnia znaczniki szablonu danymi i tworzy albo pojedynczą prezentację zawierającą powtarzające się slajdy szablonu dla każdego zestawu danych, albo oddzielną prezentację dla każdego zestawu danych.

Ta funkcjonalność jest przydatna do generowania katalogów produktów, spersonalizowanych prezentacji, raportów, certyfikatów, ofert, cenników i innych dokumentów, w których struktura prezentacji pozostaje taka sama, a treść się zmienia.

![Mail Merge: przed i po](mail-merge-before-after.png)

## **Jak działa Mail Merge**

Mail Merge używa prezentacji PowerPoint jako szablonu i zamienia znaczniki na wartości z źródła danych.

![Przebieg Mail Merge](mail-merge-workflow.png)

Znacznik to nazwa pola otoczona podwójnymi nawiasami klamrowymi, takimi jak `{{title}}` lub `{{price}}`. Znaczniki można umieszczać w tekście w kształtach, komórkach tabel, grupowanych kształtach i notatkach prelegenta.

- `Produkt: {{title}}`
- `Cena: {{price}}`
- `Opis: {{description}}`

| Pole | Wartość |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14-inch display, 16 GB RAM |

Mail Merge zastępuje znaczniki odpowiednimi wartościami, tworząc slajd z rzeczywistymi informacjami o produkcie.

Nazwy pól nie rozróżniają wielkości liter, więc `{{title}}` i `{{Title}}` odnoszą się do tego samego pola.

Następujące zasady obowiązują podczas zamiany znaczników:

- Znaczniki są zamieniane na slajdach, w tym w grupowanych kształtach i komórkach tabel, oraz w notatkach prelegenta.  
- Znaczniki na slajdach głównych i slajdach układu nie są zamieniane.  
- Znacznik, którego pola nie ma w zestawie danych, pozostaje niezmieniony.  
- Pusta wartość pola zastępuje swój znacznik pustym ciągiem.  
- Wstawiony tekst dziedziczy formatowanie pierwszego znaku znacznika.  
- Wartości nie mogą zawierać tekstu znacznika, ponieważ wstawiony tekst może być ponownie przetworzony i zamieniony przez inne pole.

Oryginalna prezentacja szablonu nie jest modyfikowana podczas operacji scalania i musi zawierać przynajmniej jeden slajd.

## **Obsługiwane źródła danych**

Mail Merge obsługuje dwa sposoby dostarczania danych:

- Utwórz źródło danych programowo przy użyciu `IMailMergeDataSource`.  
- Odczytaj dane z pliku lub strumienia CSV, XLSX, JSON lub XML.

Format danych jest wykrywany na podstawie zawartości, a nie rozszerzenia pliku. Obsługiwane są również strumienie, które nie obsługują przewijania.

Źródło danych musi zawierać co najmniej jeden zestaw danych. Każdy zestaw danych reprezentuje jedną kopię szablonu, która zostanie wypełniona jego wartościami.

Jeśli zawartość danych nie może zostać rozpoznana jako obsługiwany format, zostaje zgłoszony `NotSupportedException`. Jeśli zawartość jest rozpoznana, ale nie spełnia wymagań formatu, zostaje zgłoszony `InvalidDataException`. Wiadomość wyjątku zawiera lokalizację błędu w danych.

### **JSON**

Źródło danych JSON musi posiadać obiekt główny zawierający tablicę `sets`. Każdy element tej tablicy reprezentuje zestaw danych i musi zawierać tablicę `fields`. Każde pole musi posiadać ciągi `name` i `value`.

Opcjonalna właściwość `version` musi mieć wartość `"1.0"`, a opcjonalna właściwość `type` pola musi mieć wartość `"text"`. Nazwy właściwości rozróżniają wielkość liter. Nieznane właściwości są ignorowane.

Dane JSON są odczytywane jako UTF-8, lub jako UTF-16 gdy dane zaczynają się od znacznika kolejności bajtów (BOM).

Poniższy przykład zawiera dwa zestawy danych:

```json
{
  "version": "1.0",
  "sets": [
    {
      "fields": [
        { "name": "title", "value": "Laptop X1" },
        { "name": "price", "value": "$999" }
      ]
    },
    {
      "fields": [
        { "name": "title", "value": "Tablet S2" },
        { "name": "price", "value": "$499" }
      ]
    }
  ]
}
```

### **XML**

Źródło danych XML musi posiadać główny element `template` zawierający element `sets`. Każdy element `set` zawiera elementy `field`, a każde pole musi zawierać elementy `name` i `value`.

Pusty element `value` jest traktowany jako pusty ciąg. Nazwy elementów rozróżniają wielkość liter. Nieznane elementy i komentarze są ignorowane. Kodowanie jest określone przez deklarację XML. Definicje typu dokumentu (DTD) nie są dozwolone.

```xml
<?xml version="1.0" encoding="utf-8"?>
<template>
  <sets>
    <set>
      <field>
        <name>title</name>
        <value>Laptop X1</value>
      </field>
      <field>
        <name>price</name>
        <value>$999</value>
      </field>
    </set>
    <set>
      <field>
        <name>title</name>
        <value>Tablet S2</value>
      </field>
      <field>
        <name>price</name>
        <value>$499</value>
      </field>
    </set>
  </sets>
</template>
```

### **CSV**

Dane CSV używają średników jako separatorów wartości.

Pierwszy wiersz zawiera nazwy pól i kończy się przy pierwszej pustej nazwie pola. Każdy kolejny wiersz reprezentuje jeden zestaw danych. Dane kończą się przy pierwszym pustym wierszu.

Obowiązują następujące zasady:

- Brakujące wartości na końcu wiersza są traktowane jako puste ciągi.  
- Wartości poza zdefiniowanymi nazwami pól są ignorowane.  
- Wartość zawierająca średnik, cudzysłów lub znak końca wiersza musi być ujęta w cudzysłowy.  
- Cudzysłowy wewnątrz wartości ujętej w cudzysłowy muszą być podwojone.  
- Dane są odczytywane jako UTF-8, lub jako UTF-16 gdy zaczynają się od znacznika kolejności bajtów (BOM).

Przykład:

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### **XLSX**

Dane XLSX są odczytywane z pierwszego arkusza.

Arkusz stosuje te same zasady co CSV:

- Pierwszy wiersz zawiera nazwy pól i kończy się przy pierwszej pustej komórce.  
- Każdy kolejny wiersz reprezentuje jeden zestaw danych.  
- Dane kończą się przy pierwszym pustym wierszu.  
- Puste komórki są traktowane jako puste ciągi.  
- Wartości liczbowe są konwertowane na tekst przy użyciu kultury invariantnej.

## **Tworzenie pojedynczej prezentacji**

Metoda `MergeToSinglePresentation` tworzy jedną prezentację zawierającą kopię slajdów szablonu dla każdego zestawu danych. Każda kopia jest wypełniana odpowiednimi danymi.

Kolejność zestawów danych określa kolejność grup slajdów w wynikowej prezentacji.

### **Scalanie danych z pliku**

Poniższy przykład ładuje szablon i plik danych JSON, tworzy pojedynczą prezentację zawierającą slajdy dla wszystkich zestawów danych i zapisuje wynik.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, "products.json"))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

Dane mogą być również odczytane ze strumienia. Strumień jest odczytywany od bieżącej pozycji i nie jest zamykany przez operację Mail Merge.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Stream data = File.OpenRead("products.xml"))
using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, data))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

### **Tworzenie źródła danych w kodzie**

Możesz programowo zbudować źródło danych przy użyciu `MailMergeDataSource` i `MailMergeDataSet`. Dodaj zestaw danych dla każdego rekordu i określ jego pola przy użyciu metody `AddText`.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet laptop = source.AddDataSet();
laptop.AddText("title", "Laptop X1");
laptop.AddText("price", "$999");

IMailMergeDataSet tablet = source.AddDataSet();
tablet.AddText("title", "Tablet S2");
tablet.AddText("price", "$499");

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, source))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

W tym przykładzie slajdy szablonu są powtórzone dwukrotnie: raz dla laptopa i raz dla tabletu. Znaczniki są wypełniane wartościami zdefiniowanymi w każdym zestawie danych.

## **Tworzenie wielu prezentacji**

Jeśli potrzebujesz oddzielnej prezentacji dla każdego zestawu danych, użyj metody `MergeToMultiplePresentations`.

Ta metoda przetwarza zestawy danych jeden po drugim, tworzy prezentację na podstawie szablonu, wypełnia ją bieżącymi danymi i przekazuje wynikową prezentację do obsługi (handler).

Obsługa (handler) jest wywoływana raz dla każdego zestawu danych, w oryginalnej kolejności danych.

### **Zapisywanie każdej prezentacji**

Poniższy przykład odczytuje dane z pliku CSV i zapisuje każdą wygenerowaną prezentację jako osobny plik.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.csv",
        (presentation, args) =>
        {
            presentation.Save(
                "product_" + (args.Index + 1) + ".pptx",
                SaveFormat.Pptx);
        });
}
```

Właściwość `args.Index` dostarcza indeks zerowy bieżącego zestawu danych. W przykładzie jest ona używana do generowania kolejnych nazw plików zaczynając od `product_1.pptx`.

Dane mogą być również odczytane ze strumienia:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Stream data = File.OpenRead("products.xlsx"))
using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        data,
        (presentation, args) =>
        {
            presentation.Save(
                "product_" + (args.Index + 1) + ".pptx",
                SaveFormat.Pptx);
        });
}
```

### **Używanie wartości zestawu danych do nazw plików**

Obsługa (handler) otrzymuje zarówno wygenerowaną prezentację, jak i informacje o zestawie danych użytym do jej utworzenia. Możesz użyć wartości zestawu danych do budowy znaczących nazw plików.

Na przykład, poniższy kod zapisuje każdą prezentację używając tytułu produktu:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.json",
        (presentation, args) =>
        {
            string title = args.DataSet.GetText("title");
            string fileName = title != null
                ? title
                : "product_" + (args.Index + 1);

            presentation.Save(fileName + ".pptx", SaveFormat.Pptx);
        });
}
```

Właściwość `DataSet` zwraca zestaw danych użyty do wypełnienia bieżącej prezentacji. Metoda `GetText` pobiera wartość określonego pola lub `null`, jeśli pole nie istnieje.

Umożliwia to użycie wartości danych do nazywania plików, organizowania wyników lub stosowania dodatkowego przetwarzania w obsłudze.

## **Obsługa wygenerowanych prezentacji**

`MergeToMultiplePresentations` używa delegata `MailMergedPresentationHandler` do przetwarzania każdej wygenerowanej prezentacji.

Obsługa (handler) otrzymuje dwa argumenty:

- `presentation` — prezentacja utworzona na podstawie szablonu i wypełniona bieżącym zestawem danych.  
- `args` — informacje o wygenerowanej prezentacji, w tym indeks zestawu danych oraz sam zestaw danych.

Wygenerowana prezentacja jest własnością operacji Mail Merge i jest zwalniana natychmiast po zwróceniu się z obsługi. Dlatego należy ją zapisać lub skopiować wymagane dane wewnątrz obsługi. Nie przechowuj referencji do niej po zwróceniu się z obsługi ani nie zwalniaj jej ręcznie.

Obsługa jest wykonywana w wątku wywołującym, jedna prezentacja na raz, w kolejności zestawów danych. W danej chwili w pamięci przechowywana jest tylko jedna wygenerowana prezentacja, co czyni to podejście odpowiednim do przetwarzania dużych źródeł danych bez jednoczesnego przechowywania wszystkich wygenerowanych prezentacji w pamięci.

Jeśli obsługa (handler) zgłosi wyjątek, operacja Mail Merge zatrzymuje się, a wyjątek jest przekazywany wywołującemu bez zmian. Prezentacje już przetworzone pozostają nienaruszone, a pozostałe zestawy danych nie są przetwarzane.

Poniższy przykład zapisuje wygenerowane prezentacje do dedykowanego katalogu:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

string outputFolder = "output";
Directory.CreateDirectory(outputFolder);

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.json",
        (presentation, args) =>
        {
            string path = Path.Combine(
                outputFolder,
                "product_" + (args.Index + 1) + ".pptx");

            presentation.Save(path, SaveFormat.Pptx);
        });
}
```

## **Praca z danymi Mail Merge**

Klasa `MailMergeDataSource` reprezentuje uporządkowaną kolekcję zestawów danych. Może być używana do tworzenia danych w kodzie, sprawdzania liczby zestawów danych oraz dostępu do poszczególnych zestawów danych za pomocą indeksu.

### **Pobieranie liczby zestawów danych**

Właściwość `Count` zwraca liczbę zestawów danych w źródle.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### **Dostęp do zestawu danych po indeksie**

Właścność `Item(int)` zapewnia dostęp do zestawu danych o podanym zerowym indeksie.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

Ten przykład pobiera tytuł drugiego zestawu danych.

### **Dodawanie pól tekstowych**

Metoda `AddText` dodaje nazwane pole tekstowe do zestawu danych. Wartość pola zastępuje wszystkie pasujące znaczniki w szablonie.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

Pusta wartość usuwa odpowiadający znacznik z wynikowego tekstu. Jeśli pole nie zostanie dodane do zestawu danych, znacznik pozostaje niezmieniony.

### **Odczytywanie pól tekstowych**

Metoda `GetText` pobiera wartość pola według nazwy. Nazwy pól nie rozróżniają wielkości liter.

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

Jeśli pole nie istnieje lub podana nazwa pola jest `null`, `GetText` zwraca `null`.

## **Podsumowanie**

Mail Merge w Aspose.Slides for .NET zapewnia wygodny sposób generowania prezentacji opartych na danych z wielokrotnego użytku szablonu.

Możesz go używać do:

- Wypełniania szablonów prezentacji wartościami ze źródeł danych.  
- Generowania jednej prezentacji zawierającej powtarzające się slajdy szablonu dla wielu zestawów danych.  
- Tworzenia oddzielnej prezentacji dla każdego zestawu danych.  
- Odczytywania danych z plików lub strumieni CSV, XLSX, JSON i XML.  
- Budowania źródeł danych bezpośrednio w kodzie.  
- Przetwarzania i zapisywania wygenerowanych prezentacji kolejno przy użyciu obsługi (handler).

Łącząc wielokrotnego użytku szablony ze strukturalnymi danymi, możesz zautomatyzować tworzenie dużej liczby prezentacji, zachowując jednocześnie oddzielnie projekt szablonu i logikę przetwarzania danych.

## **Najczęściej zadawane pytania**

**Czy mogę użyć tego samego znacznika wielokrotnie w szablonie?**  
Tak. Każde wystąpienie znacznika z pasującą nazwą pola zostaje zastąpione odpowiednią wartością z bieżącego zestawu danych.

**Czy nazwy pól są rozróżniane wielkością liter?**  
Nie. Nazwy znaczników i pól danych nie rozróżniają wielkości liter. Na przykład `{{title}}`, `{{Title}}` i `{{TITLE}}` odnoszą się do tego samego pola.

**Co się dzieje, jeśli pole brakuje w zestawie danych?**  
Jeśli zestaw danych nie zawiera pola odwoływanego przez znacznik, ten znacznik pozostaje niezmieniony w wygenerowanej prezentacji.

**Co się dzieje, jeśli pole ma pustą wartość?**  
Pusta wartość pola zastępuje znacznik pustym ciągiem. Tekst znacznika zostaje usunięty, pozostawiając w jego miejscu brak tekstu.

**Czy mogę zachować formatowanie znacznika przy jego zamianie?**  
Wstawiony tekst dziedziczy formatowanie pierwszego znaku znacznika. Zastosuj pożądane formatowanie tekstu znacznika w szablonie przed wykonaniem scalania.

**Czy Mail Merge zamienia znaczniki na slajdach głównych lub układu?**  
Nie. Mail Merge zamienia znaczniki w obsługiwanej treści na slajdach prezentacji, w tym w kształtach, grupowanych kształtach, komórkach tabel i notatkach prelegenta. Znaczniki na slajdach głównych i układu nie są zamieniane.

**Czy szablon prezentacji jest modyfikowany podczas scalania?**  
Nie. Oryginalny szablon nie jest modyfikowany przez operację scalania. Możesz go ponownie używać do generowania prezentacji z tego samego lub różnych źródeł danych.

**Czy mogę generować oddzielną prezentację dla każdego zestawu danych?**  
Tak. Użyj `MergeToMultiplePresentations` i zapisz każdą wygenerowaną prezentację w obsłudze (handler). Obsługa jest wywoływana kolejno dla każdego zestawu danych.

**Czy mogę połączyć wszystkie zestawy danych w jedną prezentację?**  
Tak. Użyj `MergeToSinglePresentation`. Tworzy ona jedną prezentację wyjściową zawierającą kopię slajdów szablonu dla każdego zestawu danych, w kolejności źródła danych.

**Czy mogę użyć źródła danych bez zapisywania go do pliku?**  
Tak. Możesz utworzyć `MailMergeDataSource` w kodzie, dodać zestawy danych i wypełnić pola przy użyciu `AddText`. Jest to przydatne, gdy dane są już dostępne w aplikacji.

**Czy Mail Merge wykrywa format danych na podstawie rozszerzenia pliku?**  
Nie. Format danych jest wykrywany na podstawie zawartości, więc obsługiwane źródło danych nie musi mieć określonego rozszerzenia pliku.

**Czy mogę odczytać dane ze strumienia, który nie obsługuje przewijania?**  
Tak. Mail Merge obsługuje strumienie nieobsługujące przewijania.

**Co się dzieje, jeśli źródło danych jest puste lub nie zawiera zestawów danych?**  
Źródło danych musi zawierać co najmniej jeden zestaw danych. Upewnij się, że zawiera przynajmniej jeden rekord przed rozpoczęciem operacji scalania.

**Co się dzieje, jeśli źródło danych ma nieprawidłowy format?**  
Jeśli zawartość nie jest rozpoznana jako jeden z obsługiwanych formatów danych, zgłaszany jest `NotSupportedException`. Jeśli jest rozpoznana, ale nieprawidłowa, zgłaszany jest `InvalidDataException`. Wiadomość wyjątku zawiera informacje o lokalizacji błędu.

**Czy mogę używać wygenerowanej prezentacji po zwróceniu się z obsługi?**  
Prezentacja przekazana do obsługi `MergeToMultiplePresentations` jest własnością Mail Merge i jest zwalniana po zwróceniu się z obsługi. Zapisz ją lub skopiuj potrzebną treść wewnątrz obsługi i nie przechowuj ani nie zwalniaj tej prezentacji samodzielnie.

**Czy obsługa (handler) jest wywoływana równolegle?**  
Nie. Wygenerowane prezentacje są przetwarzane kolejno, w wątku wywołującym. W każdej chwili w pamięci przechowywana jest tylko jedna wygenerowana prezentacja.

**Co się dzieje, jeśli wewnątrz obsługi wystąpi wyjątek?**  
Operacja scalania zatrzymuje się, a wyjątek jest przekazywany wywołującemu bez zmian. Prezentacje już przetworzone nie są dotknięte, a kolejne zestawy danych nie są przetwarzane.

**Czy mogę używać wartości pól do generowania nazw plików wyjściowych?**  
Tak. Obsługa udostępnia bieżący zestaw danych poprzez swoje argumenty. Użyj `GetText`, aby pobrać pola i zbudować nazwę pliku dla każdej wygenerowanej prezentacji. Upewnij się, że wartości są prawidłowe jako nazwy plików w docelowym środowisku.