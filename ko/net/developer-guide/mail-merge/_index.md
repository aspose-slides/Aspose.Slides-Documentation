---
title: 메일 병합으로 프레젠테이션 개인화 자동화
linktitle: 메일 병합
type: docs
weight: 233
url: /ko/net/mail-merge/
keywords:
- 메일 병합
- 프레젠테이션 개인화
- 프레젠테이션 템플릿
- 텍스트 자리표시자
- 데이터 소스
- CSV
- Excel
- XLSX
- JSON
- XML
- 데이터 병합
- 프레젠테이션 생성
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 메일 병합을 사용하여 데이터로 프레젠테이션 템플릿을 채우고 CSV, Excel, JSON 및 XML 소스에서 개인화된 PowerPoint 프레젠테이션을 생성하는 방법을 배웁니다."
---
## **PowerPoint 프레젠테이션에서 메일 병합**

Aspose.Slides for .NET은 템플릿과 데이터 소스를 사용하여 PowerPoint 프레젠테이션을 자동으로 생성할 수 있습니다. 메일 병합은 템플릿 자리표시자를 데이터로 채우고, 각 데이터 세트마다 템플릿 슬라이드를 반복한 단일 프레젠테이션을 만들거나 각 데이터 세트마다 별도의 프레젠테이션을 생성합니다.

이 기능은 제품 카탈로그, 맞춤형 프레젠테이션, 보고서, 인증서, 제안서, 가격표 및 프레젠테이션 구조는 동일하지만 내용이 달라지는 기타 문서를 생성하는 데 유용합니다.

![메일 병합: 전후](mail-merge-before-after.png)


## **메일 병합 작동 방식**

메일 병합은 PowerPoint 프레젠테이션을 템플릿으로 사용하고 데이터 소스의 값으로 자리표시자를 교체합니다.

![메일 병합 작업 흐름](mail-merge-workflow.png)

자리표시자는 `{{title}}` 또는 `{{price}}`와 같이 중괄호 두 개로 둘러싼 필드 이름입니다. 자리표시자는 도형 텍스트, 표 셀, 그룹화된 도형 및 발표자 메모에 배치할 수 있습니다.

예를 들어, 템플릿 슬라이드에 다음과 같은 텍스트가 포함될 수 있습니다:

- `제품: {{title}}`
- `가격: {{price}}`
- `설명: {{description}}`

데이터 소스에 다음 값이 포함된 경우:

| 필드 | 값 |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14-inch display, 16 GB RAM |

메일 병합은 자리표시자를 해당 값으로 교체하여 실제 제품 정보가 포함된 슬라이드를 생성합니다.

필드 이름은 대소문자를 구분하지 않으므로 `{{title}}`와 `{{Title}}`은 동일한 필드를 가리킵니다.

자리표시자를 교체할 때 다음 규칙이 적용됩니다:

- 슬라이드(그룹화된 도형 및 표 셀 포함)와 발표자 메모에서 자리표시자가 교체됩니다.
- 마스터 슬라이드 및 레이아웃 슬라이드의 자리표시자는 교체되지 않습니다.
- 데이터 세트에 해당 필드가 없을 경우 자리표시자는 그대로 유지됩니다.
- 빈 필드 값은 자리표시자를 빈 문자열로 교체합니다.
- 삽입된 텍스트는 자리표시자 첫 번째 문자의 서식을 상속합니다.
- 값에 자리표시자 텍스트가 포함돼서는 안 됩니다. 삽입된 텍스트가 다시 처리되어 다른 필드로 교체될 수 있기 때문입니다.

원본 템플릿 프레젠테이션은 병합 작업 중에 수정되지 않으며 최소 하나의 슬라이드를 포함해야 합니다.

## **지원되는 데이터 소스**

메일 병합은 데이터를 제공하는 두 가지 방법을 지원합니다:

- `IMailMergeDataSource`를 사용하여 프로그래밍 방식으로 데이터 소스를 생성합니다.
- CSV, XLSX, JSON 또는 XML 파일 또는 스트림에서 데이터를 읽습니다.

데이터 형식은 파일 확장자가 아니라 내용으로 감지됩니다. 탐색을 지원하지 않는 스트림도 지원됩니다.

데이터 소스는 최소 하나의 데이터 세트를 포함해야 합니다. 각 데이터 세트는 템플릿의 복사본 하나에 해당 값으로 채워집니다.

데이터 내용이 지원되는 형식으로 인식되지 않으면 `NotSupportedException`이 발생합니다. 내용은 인식되지만 형식 요구사항을 충족하지 않으면 `InvalidDataException`이 발생합니다. 예외 메시지에는 데이터 오류 위치가 포함됩니다.

### **JSON**

JSON 데이터 소스는 `sets` 배열을 포함하는 루트 객체가 있어야 합니다. 배열의 각 요소는 데이터 세트를 나타내며 `fields` 배열을 포함해야 합니다. 각 필드는 `name`과 `value` 문자열을 가져야 합니다.

옵션인 `version` 속성은 `"1.0"`이어야 하며, 필드의 옵션인 `type` 속성은 `"text"`이어야 합니다. 속성 이름은 대소문자를 구분합니다. 알 수 없는 속성은 무시됩니다.

JSON 데이터는 UTF-8로 읽히며, 데이터가 바이트 순서 표시(BOM)로 시작하면 UTF-16으로 읽힙니다.

다음 예제에는 두 개의 데이터 세트가 포함되어 있습니다:

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

XML 데이터 소스는 `sets` 요소를 포함하는 `template` 루트 요소를 가져야 합니다. 각 `set` 요소는 `field` 요소들을 포함하고, 각 필드는 `name` 및 `value` 요소를 가져야 합니다.

빈 `value` 요소는 빈 문자열로 처리됩니다. 요소 이름은 대소문자를 구분합니다. 알 수 없는 요소와 주석은 무시됩니다. 인코딩은 XML 선언에 따라 결정됩니다. 문서 유형 정의(DTD)는 허용되지 않습니다.

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

CSV 데이터는 값 구분자로 세미콜론을 사용합니다.

첫 번째 행은 필드 이름을 포함하며 첫 번째 빈 필드 이름에서 끝납니다. 이후 각 행은 하나의 데이터 세트를 나타냅니다. 데이터는 첫 번째 빈 행에서 종료됩니다.

다음 규칙이 적용됩니다:

- 행 끝에 값이 누락된 경우 빈 문자열로 처리됩니다.
- 정의된 필드 이름을 초과하는 값은 무시됩니다.
- 값에 세미콜론, 따옴표 또는 줄 바꿈이 포함된 경우 따옴표로 묶어야 합니다.
- 인용된 값 내부의 따옴표는 두 개로 표시해야 합니다.
- 데이터는 UTF-8로 읽히며, BOM으로 시작하면 UTF-16으로 읽힙니다.

예시:

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### **XLSX**

XLSX 데이터는 첫 번째 워크시트에서 읽힙니다.

워크시트는 CSV와 동일한 규칙을 따릅니다:

- 첫 번째 행은 필드 이름을 포함하며 첫 번째 빈 셀에서 끝납니다.
- 각 이후 행은 하나의 데이터 세트를 나타냅니다.
- 데이터는 첫 번째 빈 행에서 종료됩니다.
- 빈 셀은 빈 문자열로 처리됩니다.
- 숫자 값은 불변 문화권을 사용해 텍스트로 변환됩니다.

## **단일 프레젠테이션 만들기**

`MergeToSinglePresentation` 메서드는 각 데이터 세트마다 템플릿 슬라이드 복사본을 포함하는 하나의 프레젠테이션을 생성합니다. 각 복사본은 해당 데이터로 채워집니다.

데이터 세트의 순서는 결과 프레젠테이션의 슬라이드 그룹 순서를 결정합니다.

### **파일에서 데이터 병합**

다음 예제는 템플릿과 JSON 데이터 파일을 로드하고, 모든 데이터 세트에 대한 슬라이드를 포함하는 단일 프레젠테이션을 만든 뒤 결과를 저장합니다.

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

데이터는 스트림에서도 읽을 수 있습니다. 스트림은 현재 위치부터 읽히며 메일 병합 작업에 의해 닫히지 않습니다.

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

### **코드에서 데이터 소스 생성**

`MailMergeDataSource`와 `MailMergeDataSet`을 사용하여 프로그래밍 방식으로 데이터 소스를 구축할 수 있습니다. 각 레코드마다 데이터 세트를 추가하고 `AddText` 메서드로 필드를 정의합니다.

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

이 예제에서는 템플릿 슬라이드가 두 번 반복됩니다: 노트북용 한 번, 태블릿용 한 번. 자리표시자는 각 데이터 세트에 정의된 값으로 채워집니다.

## **다중 프레젠테이션 만들기**

각 데이터 세트마다 별도의 프레젠테이션이 필요하면 `MergeToMultiplePresentations` 메서드를 사용합니다.

이 메서드는 데이터 세트를 하나씩 처리하여 템플릿에서 프레젠테이션을 만들고 현재 데이터로 채운 뒤 결과 프레젠테이션을 핸들러에 전달합니다.

핸들러는 원래 데이터 순서대로 각 데이터 세트마다 한 번씩 호출됩니다.

### **각 프레젠테이션 저장**

다음 예제는 CSV 파일에서 데이터를 읽고 생성된 각 프레젠테이션을 별도 파일로 저장합니다.

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

`args.Index` 속성은 현재 데이터 세트의 0 기반 인덱스를 제공합니다. 예제에서는 이를 사용해 `product_1.pptx`부터 시작하는 순차적인 파일 이름을 생성합니다.

데이터는 스트림에서도 읽을 수 있습니다:

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

### **데이터 세트 값을 파일 이름에 사용**

핸들러는 생성된 프레젠테이션과 이를 만든 데이터 세트에 대한 정보를 모두 받습니다. 데이터 세트 값을 사용해 의미 있는 파일 이름을 만들 수 있습니다.

예를 들어, 다음 코드는 제품 제목을 사용해 각 프레젠테이션을 저장합니다:

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

`DataSet` 속성은 현재 프레젠테이션을 채운 데이터 세트를 반환합니다. `GetText` 메서드는 지정된 필드의 값을 반환하며, 해당 필드가 없으면 `null`을 반환합니다.

이를 통해 파일 이름 지정, 출력 정리 또는 핸들러에서 추가 처리에 데이터 값을 사용할 수 있습니다.

## **생성된 프레젠테이션 처리**

`MergeToMultiplePresentations`는 각 생성된 프레젠테이션을 처리하기 위해 `MailMergedPresentationHandler` 대리자를 사용합니다.

핸들러는 두 개의 인수를 받습니다:

- `presentation` — 템플릿에서 만들고 현재 데이터 세트로 채운 프레젠테이션.
- `args` — 생성된 프레젠테이션에 대한 정보이며, 데이터 세트 인덱스와 데이터 세트 자체를 포함합니다.

생성된 프레젠테이션은 메일 병합이 소유하며 핸들러가 반환된 직후에 해제됩니다. 따라서 핸들러 내부에서 저장하거나 필요한 데이터를 복사해야 합니다. 핸들러 반환 후에 참조를 유지하거나 직접 해제하지 마세요.

핸들러는 호출 스레드에서 한 번에 하나의 프레젠테이션씩 데이터 세트 순서대로 실행됩니다. 동시에 메모리에 하나의 생성된 프레젠테이션만 보관하므로, 모든 생성 프레젠테이션을 동시에 메모리에 보관하지 않고 대용량 데이터 소스를 처리하는 데 적합합니다.

핸들러가 예외를 발생시키면 메일 병합 작업이 중단되고 예외가 변형되지 않은 채 호출자에게 전달됩니다. 이미 처리된 프레젠테이션은 영향을 받지 않으며 남은 데이터 세트는 처리되지 않습니다.

다음 예제는 생성된 프레젠테이션을 전용 디렉터리에 저장합니다:

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

## **메일 병합 데이터 작업**

`MailMergeDataSource` 클래스는 데이터 세트의 순서가 있는 컬렉션을 나타냅니다. 이를 사용해 코드에서 데이터를 생성하고, 데이터 세트 수를 확인하며, 인덱스로 개별 데이터 세트에 접근할 수 있습니다.

### **데이터 세트 수 가져오기**

`Count` 속성은 소스에 있는 데이터 세트 수를 반환합니다.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### **인덱스로 데이터 세트 접근**

`Item(int)` 속성은 지정된 0 기반 인덱스에 있는 데이터 세트에 접근할 수 있게 합니다.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

이 예제는 두 번째 데이터 세트의 제목을 가져옵니다.

### **텍스트 필드 추가**

`AddText` 메서드는 데이터 세트에 이름이 있는 텍스트 필드를 추가합니다. 필드 값은 템플릿에서 일치하는 모든 자리표시자를 교체합니다.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

빈 값은 결과 텍스트에서 해당 자리표시자를 제거합니다. 필드가 데이터 세트에 추가되지 않으면 자리표시자는 그대로 유지됩니다.

### **텍스트 필드 읽기**

`GetText` 메서드는 이름으로 필드 값을 가져옵니다. 필드 이름은 대소문자를 구분하지 않습니다.

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

필드가 존재하지 않거나 지정된 필드 이름이 `null`이면 `GetText`는 `null`을 반환합니다.

## **요약**

Aspose.Slides for .NET의 메일 병합은 재사용 가능한 템플릿에서 데이터 기반 프레젠테이션을 생성하는 편리한 방법을 제공합니다.

다음과 같이 사용할 수 있습니다:

- 데이터 소스의 값으로 프레젠테이션 템플릿을 채웁니다.
- 여러 데이터 세트에 대해 템플릿 슬라이드를 반복한 단일 프레젠테이션을 생성합니다.
- 각 데이터 세트마다 별도의 프레젠테이션을 만듭니다.
- CSV, XLSX, JSON 및 XML 파일 또는 스트림에서 데이터를 읽습니다.
- 코드에서 직접 데이터 소스를 구축합니다.
- 핸들러를 사용해 생성된 프레젠테이션을 순차적으로 처리하고 저장합니다.

재사용 가능한 템플릿과 구조화된 데이터를 결합하면 템플릿 디자인과 데이터 처리 로직을 분리한 채 대량의 프레젠테이션 생성을 자동화할 수 있습니다.

## **자주 묻는 질문**

**템플릿에서 동일한 자리표시자를 여러 번 사용할 수 있나요?**  
예. 자리표시자의 모든 발생은 현재 데이터 세트의 해당 값으로 교체됩니다.

**필드 이름은 대소문자를 구분하나요?**  
아니오. 자리표시자와 데이터 필드 이름은 대소문자를 구분하지 않습니다. 예를 들어, `{{title}}`, `{{Title}}`, `{{TITLE}}`는 동일한 필드를 가리킵니다.

**데이터 세트에 필드가 없으면 어떻게 되나요?**  
데이터 세트에 자리표시자가 참조하는 필드가 없으면 해당 자리표시자는 생성된 프레젠테이션에서 그대로 유지됩니다.

**필드에 빈 값이 있으면 어떻게 되나요?**  
빈 필드 값은 자리표시자를 빈 문자열로 교체합니다. 자리표시자 텍스트가 제거되어 해당 위치에 텍스트가 남지 않습니다.

**자리표시자를 교체할 때 서식을 유지할 수 있나요?**  
교체된 텍스트는 자리표시자 첫 번째 문자의 서식을 상속합니다. 병합을 수행하기 전에 템플릿에서 자리표시자 텍스트에 원하는 서식을 적용하세요.

**메일 병합이 마스터 슬라이드나 레이아웃 슬라이드의 자리표시자를 교체하나요?**  
아니오. 메일 병합은 도형, 그룹화된 도형, 표 셀 및 발표자 메모 등 프레젠테이션 슬라이드의 지원되는 콘텐츠에서만 자리표시자를 교체합니다. 마스터 및 레이아웃 슬라이드의 자리표시자는 교체되지 않습니다.

**병합 중에 템플릿 프레젠테이션이 수정되나요?**  
아니오. 원본 템플릿은 병합 작업에 의해 수정되지 않습니다. 동일하거나 다른 데이터 소스로 프레젠테이션을 생성할 때 재사용할 수 있습니다.

**각 데이터 세트마다 별도의 프레젠테이션을 생성할 수 있나요?**  
예. `MergeToMultiplePresentations`을 사용하고 핸들러 내부에서 각 생성된 프레젠테이션을 저장합니다. 핸들러는 각 데이터 세트마다 순차적으로 호출됩니다.

**모든 데이터 세트를 하나의 프레젠테이션으로 결합할 수 있나요?**  
예. `MergeToSinglePresentation`을 사용합니다. 이는 데이터 소스 순서대로 각 데이터 세트에 대한 템플릿 슬라이드 복사본을 포함하는 단일 출력 프레젠테이션을 생성합니다.

**파일에 저장하지 않고 데이터 소스를 사용할 수 있나요?**  
예. 코드에서 `MailMergeDataSource`를 생성하고, 데이터 세트를 추가한 뒤 `AddText`로 필드를 채울 수 있습니다. 이는 데이터가 이미 애플리케이션에 존재할 때 유용합니다.

**메일 병합이 파일 확장자로 데이터 형식을 감지하나요?**  
아니오. 데이터 형식은 내용으로 감지되므로 지원되는 데이터 소스가 특정 파일 확장자를 사용할 필요는 없습니다.

**탐색을 지원하지 않는 스트림에서 데이터를 읽을 수 있나요?**  
예. 메일 병합은 탐색을 지원하지 않는 스트림을 지원합니다.

**데이터 소스가 비어 있거나 데이터 세트가 없으면 어떻게 되나요?**  
데이터 소스는 최소 하나의 데이터 세트를 포함해야 합니다. 병합 작업을 시작하기 전에 최소 하나의 레코드가 포함되어 있는지 확인하세요.

**데이터 소스 형식이 잘못되면 어떻게 되나요?**  
내용이 지원되는 데이터 형식 중 하나로 인식되지 않으면 `NotSupportedException`이 발생합니다. 인식되지만 형식이 잘못되면 `InvalidDataException`이 발생합니다. 예외 메시지에는 오류 위치에 대한 정보가 포함됩니다.

**핸들러 반환 후에 생성된 프레젠테이션을 사용할 수 있나요?**  
`MergeToMultiplePresentations` 핸들러에 전달된 프레젠테이션은 메일 병합이 소유하며 핸들러가 반환된 후 해제됩니다. 핸들러 내부에서 저장하거나 필요한 내용을 복사하고, 해당 프레젠테이션을 직접 유지하거나 해제하지 마세요.

**핸들러가 병렬로 호출되나요?**  
아니오. 생성된 프레젠테이션은 호출자 스레드에서 순차적으로 처리됩니다. 이 작업에서는 한 번에 하나의 생성된 프레젠테이션만 메모리에 유지됩니다.

**핸들러 내부에서 예외가 발생하면 어떻게 되나요?**  
병합 작업이 중단되고 예외가 변형되지 않은 채 호출자에게 전달됩니다. 이미 처리된 프레젠테이션은 영향받지 않으며 이후 데이터 세트는 처리되지 않습니다.

**필드 값을 사용해 출력 파일 이름을 생성할 수 있나요?**  
예. 핸들러는 인수를 통해 현재 데이터 세트를 제공합니다. `GetText`를 사용해 필드를 가져오고 각 생성된 프레젠테이션에 대한 파일 이름을 만들 수 있습니다. 값이 대상 환경에서 파일 이름으로 유효한지 확인하세요.