---
title: Tự động Cá nhân hoá Bản trình chiếu với Mail Merge
linktitle: Mail Merge
type: docs
weight: 233
url: /vi/net/mail-merge/
keywords:
- Mail Merge
- cá nhân hoá bản trình chiếu
- mẫu bản trình chiếu
- trình giữ chỗ văn bản
- nguồn dữ liệu
- CSV
- Excel
- XLSX
- JSON
- XML
- hợp nhất dữ liệu
- tạo bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách sử dụng Mail Merge trong Aspose.Slides cho .NET để điền các mẫu bản trình chiếu bằng dữ liệu và tạo các bản trình chiếu PowerPoint cá nhân hoá từ nguồn CSV, Excel, JSON và XML."
---
## **Mail Merge trong Bản trình chiếu PowerPoint**

Aspose.Slides for .NET cho phép bạn tự động tạo các bản trình chiếu PowerPoint bằng cách sử dụng mẫu và nguồn dữ liệu. Mail Merge điền các trình giữ chỗ trong mẫu bằng dữ liệu và tạo hoặc một bản trình chiếu duy nhất chứa các slide mẫu được lặp lại cho mỗi bộ dữ liệu hoặc một bản trình chiếu riêng biệt cho mỗi bộ dữ liệu.

Chức năng này hữu ích cho việc tạo danh mục sản phẩm, bản trình chiếu cá nhân hoá, báo cáo, chứng chỉ, đề xuất, bảng giá và các tài liệu khác mà cấu trúc bản trình chiếu vẫn giữ nguyên trong khi nội dung thay đổi.

![Mail Merge: before and after](mail-merge-before-after.png)


## **Cách hoạt động của Mail Merge**

Mail Merge sử dụng một bản trình chiếu PowerPoint làm mẫu và thay thế các trình giữ chỗ bằng các giá trị từ nguồn dữ liệu.

![Mail Merge workflow](mail-merge-workflow.png)

Một trình giữ chỗ là tên trường được bao quanh bởi dấu ngoặc nhọn kép, chẳng hạn `{{title}}` hoặc `{{price}}`. Các trình giữ chỗ có thể được đặt trong văn bản trong các hình dạng, ô bảng, nhóm hình dạng và ghi chú người thuyết trình.

Ví dụ, một slide mẫu có thể chứa các văn bản sau:

- `Product: {{title}}`
- `Price: {{price}}`
- `Description: {{description}}`

Khi nguồn dữ liệu chứa các giá trị sau:

| Trường | Giá trị |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14-inch display, 16 GB RAM |

Mail Merge thay thế các trình giữ chỗ bằng các giá trị tương ứng, tạo ra một slide với thông tin sản phẩm thực tế.

Tên trường không phân biệt chữ hoa chữ thường, vì vậy `{{title}}` và `{{Title}}` đề cập đến cùng một trường.

Các quy tắc sau áp dụng khi thay thế các trình giữ chỗ:

- Các trình giữ chỗ được thay thế trên các slide, bao gồm cả nhóm hình dạng và ô bảng, và trong ghi chú người thuyết trình.
- Các trình giữ chỗ trên slide mẫu và slide bố cục không được thay thế.
- Một trình giữ chỗ mà trường không tồn tại trong bộ dữ liệu sẽ giữ nguyên.
- Giá trị trường rỗng sẽ thay thế trình giữ chỗ bằng chuỗi rỗng.
- Văn bản được chèn thừa hưởng định dạng của ký tự đầu tiên của trình giữ chỗ.
- Giá trị không được chứa văn bản trình giữ chỗ, vì văn bản được chèn có thể được xử lý lại và thay thế bởi một trường khác.

Bản mẫu gốc không bị sửa đổi trong quá trình hợp nhất và phải chứa ít nhất một slide.

## **Các nguồn dữ liệu được hỗ trợ**

Mail Merge hỗ trợ hai cách cung cấp dữ liệu:

- Tạo nguồn dữ liệu bằng cách lập trình sử dụng `IMailMergeDataSource`.
- Đọc dữ liệu từ tệp CSV, XLSX, JSON hoặc XML hoặc từ luồng.

Định dạng dữ liệu được phát hiện dựa trên nội dung, không phải dựa trên phần mở rộng tệp. Các luồng không hỗ trợ tìm vị trí cũng được hỗ trợ.

Nguồn dữ liệu phải chứa ít nhất một bộ dữ liệu. Mỗi bộ dữ liệu đại diện cho một bản sao của mẫu sẽ được điền các giá trị tương ứng.

Nếu nội dung dữ liệu không thể nhận dạng là định dạng được hỗ trợ, `NotSupportedException` sẽ được ném. Nếu nội dung được nhận dạng nhưng không tuân thủ các yêu cầu định dạng, `InvalidDataException` sẽ được ném. Thông báo ngoại lệ chứa vị trí lỗi trong dữ liệu.

### **JSON**

Nguồn dữ liệu JSON phải có một đối tượng gốc chứa mảng `sets`. Mỗi phần tử của mảng đại diện cho một bộ dữ liệu và phải chứa một mảng `fields`. Mỗi trường phải có chuỗi `name` và `value`.

Thuộc tính tùy chọn `version` phải là `"1.0"`, và thuộc tính tùy chọn `type` của một trường phải là `"text"`. Tên thuộc tính phân biệt chữ hoa chữ thường. Các thuộc tính không xác định sẽ bị bỏ qua.

Dữ liệu JSON được đọc dưới dạng UTF-8, hoặc UTF-16 khi dữ liệu bắt đầu bằng dấu hiệu byte order mark (BOM).

Ví dụ sau chứa hai bộ dữ liệu:

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

Nguồn dữ liệu XML phải có một phần tử gốc `template` chứa phần tử `sets`. Mỗi phần tử `set` chứa các phần tử `field`, và mỗi trường phải chứa các phần tử `name` và `value`.

Một phần tử `value` rỗng được xử lý như một chuỗi rỗng. Tên phần tử phân biệt chữ hoa chữ thường. Các phần tử và chú thích không xác định sẽ bị bỏ qua. Mã hoá được xác định bởi khai báo XML. Định nghĩa kiểu tài liệu (DTD) không được phép.

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

Dữ liệu CSV sử dụng dấu chấm phẩy làm dấu phân cách giá trị.

Dòng đầu tiên chứa tên trường và kết thúc ở trường tên đầu tiên trống. Mỗi dòng tiếp theo đại diện cho một bộ dữ liệu. Dữ liệu kết thúc ở dòng trống đầu tiên.

Các quy tắc sau áp dụng:

- Các giá trị thiếu ở cuối dòng được coi là chuỗi rỗng.
- Các giá trị vượt quá tên trường đã định nghĩa sẽ bị bỏ qua.
- Giá trị chứa dấu chấm phẩy, dấu ngoặc kép hoặc ngắt dòng phải được bao quanh bằng dấu ngoặc kép.
- Dấu ngoặc kép bên trong một giá trị được bao quanh phải được nhân đôi.
- Dữ liệu được đọc dưới dạng UTF-8, hoặc UTF-16 khi nó bắt đầu bằng dấu byte order mark (BOM).

Ví dụ:

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### **XLSX**

Dữ liệu XLSX được đọc từ bảng tính đầu tiên.

Bảng tính tuân theo cùng các quy tắc như CSV:

- Dòng đầu tiên chứa tên trường và kết thúc ở ô trống đầu tiên.
- Mỗi dòng tiếp theo đại diện cho một bộ dữ liệu.
- Dữ liệu kết thúc ở dòng trống đầu tiên.
- Các ô trống được xử lý như chuỗi rỗng.
- Các giá trị số được chuyển thành văn bản bằng cách sử dụng văn hoá invariant.

## **Tạo một Bản trình chiếu Đơn**

Phương thức `MergeToSinglePresentation` tạo một bản trình chiếu chứa một bản sao của các slide mẫu cho mỗi bộ dữ liệu. Mỗi bản sao được điền bằng dữ liệu tương ứng.

Thứ tự của các bộ dữ liệu quyết định thứ tự của các nhóm slide trong bản trình chiếu kết quả.

### **Hợp nhất Dữ liệu từ Tệp**

Ví dụ sau tải một mẫu và một tệp dữ liệu JSON, tạo một bản trình chiếu đơn chứa các slide cho tất cả các bộ dữ liệu, và lưu kết quả.

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

Dữ liệu cũng có thể được đọc từ một luồng. Luồng được đọc bắt đầu từ vị trí hiện tại và không bị đóng bởi thao tác Mail Merge.

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

### **Tạo Nguồn Dữ liệu trong Mã**

Bạn có thể xây dựng nguồn dữ liệu bằng cách lập trình sử dụng `MailMergeDataSource` và `MailMergeDataSet`. Thêm một bộ dữ liệu cho mỗi bản ghi và định nghĩa các trường của nó bằng phương thức `AddText`.

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

Trong ví dụ này, các slide mẫu được lặp lại hai lần: một lần cho laptop và một lần cho tablet. Các trình giữ chỗ được điền bằng các giá trị được định nghĩa trong mỗi bộ dữ liệu.

## **Tạo Nhiều Bản trình chiếu**

Nếu bạn cần một bản trình chiếu riêng biệt cho mỗi bộ dữ liệu, hãy sử dụng phương thức `MergeToMultiplePresentations`.

Phương thức này xử lý các bộ dữ liệu theo từng cái một, tạo một bản trình chiếu từ mẫu, điền nó bằng dữ liệu hiện tại, và truyền bản trình chiếu kết quả cho một bộ xử lý.

Bộ xử lý được gọi một lần cho mỗi bộ dữ liệu, theo thứ tự dữ liệu gốc.

### **Lưu Mỗi Bản trình chiếu**

Ví dụ sau đọc dữ liệu từ tệp CSV và lưu mỗi bản trình chiếu được tạo ra dưới dạng tệp riêng.

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

Thuộc tính `args.Index` cung cấp chỉ mục dựa trên zero của bộ dữ liệu hiện tại. Trong ví dụ, nó được dùng để tạo tên tệp tuần tự bắt đầu từ `product_1.pptx`.

Dữ liệu cũng có thể được đọc từ một luồng:

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

### **Sử dụng Giá trị Bộ dữ liệu để Đặt Tên Tệp**

Bộ xử lý nhận cả bản trình chiếu đã tạo và thông tin về bộ dữ liệu được dùng để tạo nó. Bạn có thể sử dụng các giá trị bộ dữ liệu để xây dựng các tên tệp có ý nghĩa.

Ví dụ, đoạn mã sau lưu mỗi bản trình chiếu bằng tiêu đề sản phẩm:

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

Thuộc tính `DataSet` trả về bộ dữ liệu được dùng để điền bản trình chiếu hiện tại. Phương thức `GetText` lấy giá trị của một trường được chỉ định, hoặc `null` nếu trường không tồn tại.

Điều này cho phép bạn sử dụng các giá trị dữ liệu để đặt tên tệp, tổ chức đầu ra, hoặc thực hiện xử lý bổ sung trong bộ xử lý.

## **Xử lý Các Bản trình chiếu Được Tạo**

`MergeToMultiplePresentations` sử dụng delegate `MailMergedPresentationHandler` để xử lý mỗi bản trình chiếu được tạo.

Bộ xử lý nhận hai tham số:

- `presentation` — bản trình chiếu được tạo từ mẫu và được điền bằng bộ dữ liệu hiện tại.
- `args` — thông tin về bản trình chiếu đã tạo, bao gồm chỉ mục bộ dữ liệu và chính bộ dữ liệu.

Bản trình chiếu được tạo thuộc quyền sở hữu của Mail Merge và sẽ bị giải phóng ngay sau khi bộ xử lý trả về. Do đó, bạn phải lưu nó hoặc sao chép bất kỳ dữ liệu cần thiết nào bên trong bộ xử lý. Không giữ tham chiếu đến nó sau khi bộ xử lý trả về hoặc giải phóng nó thủ công.

Bộ xử lý được thực thi trên luồng gọi, một bản trình chiếu mỗi lần, theo thứ tự của các bộ dữ liệu. Chỉ một bản trình chiếu được giữ trong bộ nhớ tại một thời điểm, làm cho cách tiếp cận này phù hợp cho việc xử lý các nguồn dữ liệu lớn mà không cần giữ tất cả các bản trình chiếu trong bộ nhớ đồng thời.

Nếu bộ xử lý ném ra ngoại lệ, thao tác Mail Merge dừng lại và ngoại lệ sẽ được truyền lại cho người gọi mà không thay đổi. Các bản trình chiếu đã được xử lý trước đó không bị ảnh hưởng, và các bộ dữ liệu còn lại sẽ không được xử lý.

Ví dụ sau lưu các bản trình chiếu đã tạo vào một thư mục riêng:

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

## **Làm việc với Dữ liệu Mail Merge**

Lớp `MailMergeDataSource` đại diện cho một tập hợp có thứ tự các bộ dữ liệu. Nó có thể được dùng để tạo dữ liệu trong mã, kiểm tra số lượng bộ dữ liệu, và truy cập các bộ dữ liệu riêng lẻ theo chỉ mục.

### **Lấy Số lượng Bộ dữ liệu**

Thuộc tính `Count` trả về số lượng bộ dữ liệu trong nguồn.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### **Truy cập Bộ dữ liệu theo Chỉ mục**

Thuộc tính `Item(int)` cung cấp quyền truy cập vào một bộ dữ liệu tại chỉ mục zero‑based được chỉ định.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

Ví dụ này lấy tiêu đề của bộ dữ liệu thứ hai.

### **Thêm Trường Văn bản**

Phương thức `AddText` thêm một trường văn bản có tên vào một bộ dữ liệu. Giá trị trường sẽ thay thế tất cả các trình giữ chỗ phù hợp trong mẫu.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

Giá trị rỗng sẽ xóa trình giữ chỗ tương ứng khỏi văn bản kết quả. Nếu trường không được thêm vào bộ dữ liệu, trình giữ chỗ sẽ giữ nguyên.

### **Đọc Trường Văn bản**

Phương thức `GetText` trả về giá trị của một trường theo tên. Tên trường không phân biệt chữ hoa chữ thường.

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

Nếu trường không tồn tại hoặc tên trường được chỉ định là `null`, `GetText` sẽ trả về `null`.

## **Tóm tắt**

Mail Merge trong Aspose.Slides for .NET cung cấp một cách tiện lợi để tạo các bản trình chiếu dựa trên dữ liệu từ một mẫu có thể tái sử dụng.

Bạn có thể sử dụng nó để:

- Điền các mẫu bản trình chiếu bằng các giá trị từ nguồn dữ liệu.
- Tạo một bản trình chiếu duy nhất chứa các slide mẫu lặp lại cho nhiều bộ dữ liệu.
- Tạo một bản trình chiếu riêng biệt cho mỗi bộ dữ liệu.
- Đọc dữ liệu từ các tệp CSV, XLSX, JSON và XML hoặc từ luồng.
- Xây dựng nguồn dữ liệu trực tiếp trong mã.
- Xử lý và lưu các bản trình chiếu được tạo ra một cách tuần tự bằng một bộ xử lý.

Bằng cách kết hợp các mẫu có thể tái sử dụng với dữ liệu có cấu trúc, bạn có thể tự động tạo ra số lượng lớn bản trình chiếu trong khi giữ thiết kế mẫu và logic xử lý dữ liệu tách biệt.

## **Câu hỏi thường gặp**

**Tôi có thể sử dụng cùng một placeholder nhiều lần trong mẫu không?**

Có. Mỗi lần xuất hiện của một trình giữ chỗ với tên trường phù hợp sẽ được thay thế bằng giá trị tương ứng từ bộ dữ liệu hiện tại.

**Tên trường có phân biệt chữ hoa chữ thường không?**

Không. Tên trình giữ chỗ và tên trường dữ liệu không phân biệt chữ hoa chữ thường. Ví dụ, `{{title}}`, `{{Title}}` và `{{TITLE}}` đều đề cập đến cùng một trường.

**Nếu một trường thiếu trong bộ dữ liệu thì sẽ xảy ra gì?**

Nếu bộ dữ liệu không chứa trường được tham chiếu bởi một trình giữ chỗ, trình giữ chỗ đó sẽ giữ nguyên trong bản trình chiếu đã tạo.

**Nếu một trường có giá trị rỗng thì sẽ xảy ra gì?**

Giá trị trường rỗng sẽ thay thế trình giữ chỗ bằng một chuỗi rỗng. Văn bản trình giữ chỗ sẽ bị xóa, không để lại bất kỳ ký tự nào ở vị trí đó.

**Tôi có thể giữ nguyên định dạng của trình giữ chỗ khi thay thế không?**

Văn bản thay thế thừa hưởng định dạng của ký tự đầu tiên của trình giữ chỗ. Hãy áp dụng định dạng mong muốn cho văn bản trình giữ chỗ trong mẫu trước khi thực hiện hợp nhất.

**Mail Merge có thay thế trình giữ chỗ trên slide mẫu hoặc slide bố cục không?**

Không. Mail Merge chỉ thay thế các trình giữ chỗ trong nội dung hỗ trợ trên các slide trình chiếu, bao gồm các hình dạng, nhóm hình dạng, ô bảng và ghi chú người thuyết trình. Các trình giữ chỗ trên slide mẫu và slide bố cục không được thay thế.

**Mẫu bản trình chiếu có bị sửa đổi trong quá trình hợp nhất không?**

Không. Mẫu gốc không bị thay đổi bởi thao tác hợp nhất. Bạn có thể tái sử dụng nó để tạo các bản trình chiếu từ cùng hoặc các nguồn dữ liệu khác nhau.

**Tôi có thể tạo một bản trình chiếu riêng biệt cho mỗi bộ dữ liệu không?**

Có. Sử dụng `MergeToMultiplePresentations` và lưu mỗi bản trình chiếu đã tạo bên trong bộ xử lý. Bộ xử lý sẽ được gọi tuần tự cho mỗi bộ dữ liệu.

**Tôi có thể gộp tất cả các bộ dữ liệu thành một bản trình chiếu không?**

Có. Sử dụng `MergeToSinglePresentation`. Nó tạo một bản trình chiếu đầu ra duy nhất chứa một bản sao của các slide mẫu cho mỗi bộ dữ liệu, theo thứ tự của nguồn dữ liệu.

**Tôi có thể sử dụng nguồn dữ liệu mà không lưu nó vào tệp không?**

Có. Bạn có thể tạo một `MailMergeDataSource` trong mã, thêm các bộ dữ liệu và điền các trường bằng `AddText`. Điều này hữu ích khi dữ liệu của bạn đã có sẵn trong ứng dụng.

**Mail Merge có phát hiện định dạng dữ liệu dựa trên phần mở rộng tệp không?**

Không. Định dạng dữ liệu được phát hiện từ nội dung, do đó một nguồn dữ liệu được hỗ trợ không bắt buộc phải có phần mở rộng tệp cụ thể.

**Tôi có thể đọc dữ liệu từ luồng không hỗ trợ tìm vị trí không?**

Có. Mail Merge hỗ trợ các luồng không thể tìm vị trí.

**Nếu nguồn dữ liệu rỗng hoặc không chứa bộ dữ liệu nào thì sẽ xảy ra gì?**

Nguồn dữ liệu phải chứa ít nhất một bộ dữ liệu. Hãy đảm bảo nó có ít nhất một bản ghi trước khi bắt đầu thao tác hợp nhất.

**Nếu nguồn dữ liệu có định dạng không hợp lệ thì sẽ xảy ra gì?**

Nếu nội dung không được nhận dạng là một trong các định dạng dữ liệu được hỗ trợ, `NotSupportedException` sẽ được ném. Nếu nội dung được nhận dạng nhưng không đúng định dạng, `InvalidDataException` sẽ được ném. Thông báo ngoại lệ sẽ bao gồm thông tin về vị trí lỗi.

**Tôi có thể sử dụng bản trình chiếu đã tạo sau khi bộ xử lý trả về không?**

Bản trình chiếu được truyền cho bộ xử lý `MergeToMultiplePresentations` thuộc quyền sở hữu của Mail Merge và sẽ bị giải phóng sau khi bộ xử lý trả về. Hãy lưu nó hoặc sao chép nội dung bạn cần bên trong bộ xử lý, và không giữ hoặc giải phóng bản trình chiếu này bằng cách tự mình.

**Bộ xử lý có được gọi song song không?**

Không. Các bản trình chiếu được tạo ra được xử lý tuần tự, trên luồng gọi. Chỉ một bản trình chiếu được giữ trong bộ nhớ tại một thời điểm bởi thao tác này.

**Nếu xảy ra ngoại lệ trong bộ xử lý thì sẽ thế nào?**

Thao tác hợp nhất sẽ dừng lại, và ngoại lệ sẽ được truyền lại cho người gọi mà không thay đổi. Các bản trình chiếu đã được xử lý không bị ảnh hưởng, và các bộ dữ liệu còn lại sẽ không được xử lý.

**Tôi có thể sử dụng giá trị trường để tạo tên tệp đầu ra không?**

Có. Bộ xử lý cung cấp bộ dữ liệu hiện tại thông qua các tham số của nó. Sử dụng `GetText` để lấy các trường và xây dựng tên tệp cho mỗi bản trình chiếu đã tạo. Đảm bảo các giá trị hợp lệ cho tên tệp trong môi trường mục tiêu của bạn.