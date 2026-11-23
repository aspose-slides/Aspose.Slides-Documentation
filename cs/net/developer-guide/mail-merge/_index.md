---
title: Automatizace personalizace prezentací pomocí Mail Merge
linktitle: Mail Merge
type: docs
weight: 233
url: /cs/net/mail-merge/
keywords:
- Mail Merge
- personalizace prezentace
- šablona prezentace
- textové zástupné symboly
- zdroj dat
- CSV
- Excel
- XLSX
- JSON
- XML
- sloučit data
- generovat prezentace
- .NET
- C#
- Aspose.Slides
description: "Zjistěte, jak používat Mail Merge v Aspose.Slides pro .NET k vyplnění šablon prezentací daty a generování personalizovaných prezentací PowerPoint z CSV, Excel, JSON a XML zdrojů."
---
# Mail Merge v prezentacích PowerPoint

Aspose.Slides pro .NET umožňuje automaticky generovat prezentace PowerPoint pomocí šablony a zdroje dat. Mail Merge vyplní zástupné symboly šablony daty a vytvoří buď jednu prezentaci obsahující opakované snímky šablony pro každou datovou sadu, nebo samostatnou prezentaci pro každou datovou sadu.

Tato funkce je užitečná pro generování katalogů produktů, personalizovaných prezentací, zpráv, certifikátů, nabídek, ceníků a dalších dokumentů, kde struktura prezentace zůstává stejná, zatímco obsah se mění.

![Mail Merge: před a po](mail-merge-before-after.png)


## Jak Mail Merge funguje

Mail Merge používá prezentaci PowerPoint jako šablonu a nahrazuje zástupné symboly hodnotami ze zdroje dat.

![Pracovní postup Mail Merge](mail-merge-workflow.png)

Zástupný symbol je název pole uzavřený v dvojitých složených závorkách, například `{{title}}` nebo `{{price}}`. Zástupné symboly lze umístit do textu ve tvarech, buňkách tabulek, seskupených tvarech a poznámkách řečníka.

Například snímek šablony může obsahovat následující text:

- `Produkt: {{title}}`
- `Cena: {{price}}`
- `Popis: {{description}}`

Když zdroj dat obsahuje následující hodnoty:

| Pole | Hodnota |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14-inch display, 16 GB RAM |

Mail Merge nahradí zástupné symboly odpovídajícími hodnotami a vytvoří snímek se skutečnými informacemi o produktu.

Názvy polí nejsou citlivé na velikost písmen, takže `{{title}}` a `{{Title}}` odkazují na stejné pole.

Na nahrazování zástupných symbolů se vztahují následující pravidla:

- Zástupné symboly jsou nahrazovány na snímcích, včetně seskupených tvarů a buněk tabulek, a v poznámkách řečníka.
- Zástupné symboly na hlavních snímcích a snímcích rozvržení nejsou nahrazeny.
- Zástupný symbol, jehož pole není v datové sadě přítomno, zůstane nezměněn.
- Prázdná hodnota pole nahradí svůj zástupný symbol prázdným řetězcem.
- Vložený text zdědí formátování prvního znaku zástupného symbolu.
- Hodnoty nesmí obsahovat text zástupného symbolu, protože vložený text může být znovu zpracován a nahrazen jiným polem.

Původní šablona prezentace není během operace sloučení upravena a musí obsahovat alespoň jeden snímek.

## Podporované zdroje dat

Mail Merge podporuje dva způsoby poskytování dat:

- Vytvořit zdroj dat programově pomocí `IMailMergeDataSource`.
- Načíst data ze souboru nebo proudu CSV, XLSX, JSON nebo XML.

Formát dat je detekován podle jeho obsahu, nikoli podle přípony souboru. Proudům, které nepodporují hledání, je také podporováno.

Zdroj dat musí obsahovat alespoň jednu datovou sadu. Každá datová sada představuje jednu kopii šablony, která má být vyplněna jejími hodnotami.

Pokud obsah dat nelze rozpoznat jako podporovaný formát, je vyvolána výjimka `NotSupportedException`. Pokud je obsah rozpoznán, ale nevyhovuje požadavkům formátu, je vyvolána výjimka `InvalidDataException`. Zpráva výjimky obsahuje umístění chyby v datech.

### JSON

JSON zdroj dat musí mít kořenový objekt obsahující pole `sets`. Každý prvek pole představuje datovou sadu a musí obsahovat pole `fields`. Každé pole musí mít řetězce `name` a `value`.

Volitelná vlastnost `version` musí být "1.0" a volitelná vlastnost `type` pole musí být "text". Názvy vlastností jsou citlivé na velikost písmen. Neznámé vlastnosti jsou ignorovány.

JSON data jsou čtena jako UTF-8, nebo jako UTF-16, pokud data začínají byte order mark (BOM).

Následující příklad obsahuje dvě datové sady:

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

### XML

XML zdroj dat musí mít kořenový prvek `template` obsahující prvek `sets`. Každý prvek `set` obsahuje elementy `field` a každé pole musí obsahovat elementy `name` a `value`.

Prázdný element `value` je považován za prázdný řetězec. Názvy elementů jsou citlivé na velikost písmen. Neznámé elementy a komentáře jsou ignorovány. Kódování je určeno deklarací XML. Definice typů dokumentů (DTD) nejsou povoleny.

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

### CSV

CSV data používají středníky jako oddělovače hodnot.

První řádek obsahuje názvy polí a končí při prvním prázdném názvu pole. Každý následující řádek představuje jednu datovou sadu. Data končí při první prázdné řádce.

Platí následující pravidla:

- Chybějící hodnoty na konci řádku jsou považovány za prázdné řetězce.
- Hodnoty mimo definované názvy polí jsou ignorovány.
- Hodnota obsahující středník, uvozovku nebo zalomení řádku musí být uzavřena v uvozovkách.
- Uvozovky uvnitř uvozené hodnoty musí být zdvojeny.
- Data jsou čtena jako UTF-8, nebo jako UTF-16, pokud začínají byte order mark (BOM).

Příklad:

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### XLSX

XLSX data jsou čtena z první pracovní listu.

Pracovní list následuje stejná pravidla jako CSV:

- První řádek obsahuje názvy polí a končí při první prázdné buňce.
- Každý následující řádek představuje jednu datovou sadu.
- Data končí při první prázdné řádce.
- Prázdné buňky jsou považovány za prázdné řetězce.
- Číselné hodnoty jsou převedeny na text pomocí invariantní kultury.

## Vytvoření jedné prezentace

Metoda `MergeToSinglePresentation` vytvoří jednu prezentaci obsahující kopii snímků šablony pro každou datovou sadu. Každá kopie je vyplněna odpovídajícími daty.

Pořadí datových sad určuje pořadí skupin snímků ve výsledné prezentaci.

### Sloučení dat ze souboru

Následující příklad načte šablonu a soubor JSON s daty, vytvoří jednu prezentaci obsahující snímky pro všechny datové sady a uloží výsledek.

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

Data lze také načíst ze streamu. Stream se čte od jeho aktuální pozice a není uzavřen operací Mail Merge.

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

### Vytvoření zdroje dat v kódu

Můžete programově vytvořit zdroj dat pomocí `MailMergeDataSource` a `MailMergeDataSet`. Přidejte datovou sadu pro každý záznam a definujte její pole pomocí metody `AddText`.

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

V tomto příkladu jsou snímky šablony opakovány dvakrát: jednou pro notebook a jednou pro tablet. Zástupné symboly jsou vyplněny pomocí hodnot definovaných v každé datové sadě.

## Vytvoření více prezentací

Pokud potřebujete samostatnou prezentaci pro každou datovou sadu, použijte metodu `MergeToMultiplePresentations`.

Tato metoda zpracovává datové sady po jedné, vytvoří prezentaci ze šablony, vyplní ji aktuálními daty a předá výslednou prezentaci obslužné funkci.

Obslužná funkce je zavolána jednou pro každou datovou sadu v původním pořadí dat.

### Uložení každé prezentace

Následující příklad načte data ze souboru CSV a uloží každou vygenerovanou prezentaci jako samostatný soubor.

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

Vlastnost `args.Index` poskytuje nulový index aktuální datové sady. V příkladu se používá k vytvoření posloupných názvů souborů počínaje `product_1.pptx`.

Data lze také načíst ze streamu:

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

### Použití hodnot datové sady pro pojmenování souborů

Obslužná funkce získá jak vygenerovanou prezentaci, tak informace o datové sadě použité k jejímu vytvoření. Můžete použít hodnoty datové sady k vytvoření smysluplných názvů souborů.

Například následující kód uloží každou prezentaci pomocí názvu produktu:

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

Vlastnost `DataSet` vrací datovou sadu použitou k vyplnění aktuální prezentace. Metoda `GetText` získá hodnotu zadaného pole nebo `null`, pokud pole není přítomno.

To vám umožní použít hodnoty dat pro pojmenování souborů, organizaci výstupu nebo aplikaci dalšího zpracování v obslužné funkci.

## Zpracování vygenerovaných prezentací

`MergeToMultiplePresentations` používá delegáta `MailMergedPresentationHandler` ke zpracování každé vygenerované prezentace.

Obslužná funkce přijímá dva argumenty:

- `presentation` — prezentace vytvořená ze šablony a vyplněná aktuální datovou sadou.
- `args` — informace o vygenerované prezentaci, včetně indexu datové sady a samotné datové sady.

Vygenerovaná prezentace je vlastněna operací Mail Merge a je okamžitě uvolněna po návratu obslužné funkce. Proto ji musíte uložit nebo zkopírovat potřebná data uvnitř obslužné funkce. Neukládejte odkaz na ni po návratu obslužné funkce ani ji neodstraňujte ručně.

Obslužná funkce je spuštěna na volajícím vlákně, jedna prezentace po druhé, v pořadí datových sad. V jednom okamžiku je v paměti udržována pouze jedna vygenerovaná prezentace, což činí tento přístup vhodným pro zpracování velkých zdrojů dat, aniž by byly všechny vygenerované prezentace současně uchovávány v paměti.

Pokud obslužná funkce vyvolá výjimku, operace Mail Merge se zastaví a výjimka je předána volajícímu beze změny. Již zpracované prezentace zůstávají nedotčeny a zbývající datové sady nejsou zpracovány.

Následující příklad ukládá vygenerované prezentace do vyhrazeného adresáře:

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

## Práce s daty Mail Merge

Třída `MailMergeDataSource` představuje uspořádanou kolekci datových sad. Lze ji použít k vytvoření dat v kódu, prozkoumání počtu datových sad a přístupu k jednotlivým datovým sadám podle indexu.

### Získání počtu datových sad

Vlastnost `Count` vrací počet datových sad ve zdroji.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### Přístup k datové sadě podle indexu

Vlastnost `Item(int)` poskytuje přístup k datové sadě na zadaném nulovým indexu.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

Tento příklad získá název druhé datové sady.

### Přidání textových polí

Metoda `AddText` přidá pojmenované textové pole do datové sady. Hodnota pole nahradí všechny odpovídající zástupné symboly v šabloně.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

Prázdná hodnota odstraní odpovídající zástupný symbol z výsledného textu. Pokud pole není do datové sady přidáno, zástupný symbol zůstane nezměněn.

### Čtení textových polí

Metoda `GetText` získá hodnotu pole podle názvu. Názvy polí nejsou citlivé na velikost písmen.

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

Pokud pole neexistuje nebo je zadaný název pole `null`, `GetText` vrací `null`.

## Shrnutí

Mail Merge v Aspose.Slides pro .NET poskytuje pohodlný způsob, jak generovat prezentace řízené daty z opakovaně použitelné šablony.

Můžete jej použít k:

- Vyplnit šablony prezentací hodnotami ze zdrojů dat.
- Vytvořit jednu prezentaci obsahující opakované snímky šablony pro více datových sad.
- Vytvořit samostatnou prezentaci pro každou datovou sadu.
- Načíst data ze souborů nebo proudů CSV, XLSX, JSON a XML.
- Vytvořit zdroje dat přímo v kódu.
- Zpracovávat a ukládat vygenerované prezentace sekvenčně pomocí obslužné funkce.

Kombinací opakovaně použitelné šablony se strukturovanými daty můžete automatizovat vytváření velkého množství prezentací a přitom udržet návrh šablony a logiku zpracování dat oddělené.

## Často kladené otázky

### Mohu použít stejný zástupný symbol vícekrát v šabloně?

Ano. Každý výskyt zástupného symbolu s odpovídajícím názvem pole je nahrazen odpovídající hodnotou z aktuální datové sady.

### Jsou názvy polí citlivé na velikost písmen?

Ne. Názvy zástupných symbolů i datových polí nejsou citlivé na velikost písmen. Například `{{title}}`, `{{Title}}` a `{{TITLE}}` odkazují na stejné pole.

### Co se stane, pokud v datové sadě chybí pole?

Pokud datová sada neobsahuje pole odkazované zástupným symbolem, tento zástupný symbol zůstane vygenerované prezentaci nezměněn.

### Co se stane, pokud má pole prázdnou hodnotu?

Prázdná hodnota pole nahradí zástupný symbol prázdným řetězcem. Text zástupného symbolu je odstraněn, takže v jeho místě není žádný text.

### Mohu zachovat formátování zástupného symbolu při jeho nahrazení?

Vložený text zdědí formátování prvního znaku zástupného symbolu. Požadované formátování aplikujte na text zástupného symbolu v šabloně před provedením sloučení.

### Nahrazuje Mail Merge zástupné symboly na hlavních snímcích nebo snímcích rozvržení?

Ne. Mail Merge nahrazuje zástupné symboly v podporovaném obsahu snímků prezentace, včetně tvarů, seskupených tvarů, buněk tabulek a poznámek řečníka. Zástupné symboly na hlavních a rozvržových snímcích nejsou nahrazeny.

### Je šablona prezentace během sloučení upravena?

Ne. Původní šablona není operací sloučení upravena. Můžete ji znovu použít k vytvoření prezentací ze stejných nebo různých zdrojů dat.

### Mohu vytvořit samostatnou prezentaci pro každou datovou sadu?

Ano. Použijte `MergeToMultiplePresentations` a uložte každou vygenerovanou prezentaci v rámci obslužné funkce. Obslužná funkce je volána sekvenčně pro každou datovou sadu.

### Mohu sloučit všechny datové sady do jedné prezentace?

Ano. Použijte `MergeToSinglePresentation`. Vytvoří jednu výstupní prezentaci obsahující kopii snímků šablony pro každou datovou sadu v pořadí zdroje dat.

### Mohu použít zdroj dat bez uložení do souboru?

Ano. Můžete vytvořit `MailMergeDataSource` v kódu, přidat datové sady a naplnit pole pomocí `AddText`. To je užitečné, když jsou vaše data již k dispozici ve vaší aplikaci.

### Detekuje Mail Merge formát dat z přípony souboru?

Ne. Formát dat je detekován z obsahu, takže podporovaný zdroj dat nemusí mít konkrétní příponu souboru.

### Mohu číst data ze streamu, který nepodporuje hledání?

Ano. Mail Merge podporuje nesekovatelná proudu.

### Co se stane, pokud je zdroj dat prázdný nebo neobsahuje žádné datové sady?

Zdroj dat musí obsahovat alespoň jednu datovou sadu. Ujistěte se, že obsahuje alespoň jeden záznam před zahájením operace sloučení.

### Co se stane, pokud má zdroj dat neplatný formát?

Pokud obsah není rozpoznán jako jeden z podporovaných datových formátů, je vyvolána výjimka `NotSupportedException`. Pokud je rozpoznán, ale je poškozený, je vyvolána výjimka `InvalidDataException`. Zpráva výjimky obsahuje informace o umístění chyby.

### Mohu použít vygenerovanou prezentaci po návratu obslužné funkce?

Prezentace předaná obslužné funkci `MergeToMultiplePresentations` je vlastněna Mail Merge a po návratu obslužné funkce je uvolněna. Uložte ji nebo zkopírujte potřebný obsah uvnitř obslužné funkce a neukládejte ani neodstraňujte tuto prezentaci sami.

### Je obslužná funkce volána paralelně?

Ne. Vygenerované prezentace jsou zpracovávány sekvenčně, na vlákně volajícího. V jednom okamžiku je v paměti držena pouze jedna vygenerovaná prezentace, což činí tento přístup vhodným pro zpracování velkých zdrojů dat, aniž by byly všechny vygenerované prezentace současně v paměti.

### Co se stane, pokud dojde k výjimce uvnitř obslužné funkce?

Operace sloučení se zastaví a výjimka je předána volajícímu beze změny. Již zpracované prezentace nejsou ovlivněny a následné datové sady nejsou zpracovány.

### Mohu použít hodnoty polí pro generování názvů výstupních souborů?

Ano. Obslužná funkce poskytuje aktuální datovou sadu prostřednictvím svých argumentů. Použijte `GetText` k získání polí a vytvořte název souboru pro každou vygenerovanou prezentaci. Ujistěte se, že hodnoty jsou platné pro názvy souborů ve vašem cílovém prostředí.