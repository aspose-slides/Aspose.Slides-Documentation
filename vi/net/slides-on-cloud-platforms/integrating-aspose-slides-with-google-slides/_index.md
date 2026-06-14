---
title: Tích hợp Aspose.Slides với Google Slides
linktitle: Google Slides
type: docs
weight: 50
url: /vi/net/integrating-aspose-slides-with-google-slides/
keywords:
- nền tảng đám mây
- tích hợp đám mây
- Google Slides
- Google Drive
- Google API
- Google Service Account
- tích hợp SaaS
- OAuth 2.0
- PPT sang PDF
- tự động hoá PowerPoint
- xử lý bài thuyết trình
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Kết nối Aspose.Slides với Google Slides để nhập, đồng bộ và chuyển đổi bài thuyết trình, tự động hoá quy trình làm việc, và duy trì PowerPoint và OpenDocument trong cùng một quy trình."
---
## **Giới thiệu**

Aspose.Slides hiện cung cấp tích hợp với Google Slides và Google Drive thông qua [SaaS Integration API](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations). Tích hợp này cho phép các ứng dụng .NET chuyển đổi, chỉnh sửa, tải xuống và tải lên các bài thuyết trình Google Slides.

## **Google Slides là gì?**
[Google Slides](https://workspace.google.com/products/slides/vi/) là một phần mềm thuyết trình dựa trên web miễn phí được Google phát triển. Nó cho phép người dùng tạo, chỉnh sửa và chia sẻ các bản trình bày slide trực tuyến, tương tự như Microsoft PowerPoint. Nó hỗ trợ cộng tác thời gian thực, lưu trữ đám mây và hoạt động trên bất kỳ thiết bị nào có kết nối internet.

## **Google API**
Trước khi bắt đầu làm việc với bài thuyết trình Google Slides của bạn qua Aspose.Slides, bạn phải tạo một dự án Google API và tạo một [Google Cloud project](https://developers.google.com/workspace/guides/create-project), sau đó bật các API cần thiết. 

Sau đó bạn phải chọn cách bạn sẽ truy cập Google API - [Aspose.SlideS Google Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) hỗ trợ hai cách truy cập Google API: 
- `Google Service Account`
- `OAuth 2.0` với sự tương tác của người dùng qua trình duyệt.

### **Google Service Account**
Một tài khoản dịch vụ là một tài khoản Google đặc biệt được các ứng dụng hoặc máy chủ sử dụng để truy cập Google API một cách lập trình mà không cần tương tác của người dùng. Nó thường được dùng cho các hệ thống backend hoặc các tác vụ tự động. Tài khoản dịch vụ được xác thực bằng tệp khóa JSON và có địa chỉ email riêng. Nó có thể được cấp quyền cụ thể thông qua [Google Cloud IAM](https://cloud.google.com/iam/docs/overview) và thường được dùng với các API như Google Drive, Sheets hoặc BigQuery để truy cập tài nguyên một cách an toàn và tự động.

### **OAuth 2.0**
Một cách phổ biến khác để truy cập Google API là thông qua OAuth 2.0 với sự tương tác của người dùng qua trình duyệt. Trong luồng này, người dùng được chuyển hướng tới trang đăng nhập của Google để cấp quyền cho ứng dụng. Sau khi cấp quyền, ứng dụng nhận được mã ủy quyền, rồi đổi mã này lấy token truy cập và token làm mới.

Token truy cập cho phép truy cập tạm thời vào Google API, trong khi token làm mới có thể được lưu và sử dụng lại để lấy token truy cập mới mà không cần người dùng đăng nhập lại. Điều này có nghĩa là chỉ cần tương tác với trình duyệt một lần, các lần truy cập API tiếp theo sẽ được tự động hoá hoàn toàn. Phương pháp này thường được dùng cho các ứng dụng cần truy cập dữ liệu của người dùng (như Gmail, Calendar hoặc Drive) với sự đồng ý của người dùng.

## **Hãy viết mã**
Đầu tiên, thêm [Aspose.Slides SaaS Integration NuGet package](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) vào dự án của bạn:

```
dotnet add package Aspose.Slides.SaaSIntegrations
```

### **Ví dụ 1**
Trong ví dụ sau, chúng ta sẽ tải xuống một bài thuyết trình Google Slides từ Google Drive và lưu nó vào đĩa cục bộ dưới dạng tệp PDF. Chúng ta sẽ sử dụng Google Service Account để ủy quyền, giả sử tệp JSON của tài khoản dịch vụ đã được tải xuống.

```csharp
// Tạo HttpClient được quản lý bên ngoài
HttpClient httpClient = new HttpClient();

// Tạo nhà cung cấp ủy quyền bằng tệp JSON tài khoản dịch vụ
IGoogleAuthorizationProvider account = new GoogleServiceAccountAuthProvider(@"service_account_json_file.json", httpClient);

// Khởi tạo dịch vụ tích hợp Google Slides với nhà cung cấp ủy quyền
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Tải một bài thuyết trình từ Google Drive bằng ID tệp vào một thể hiện IPresentation của Aspose.Slides
using IPresentation pres = await googleSlidesIntegration.LoadPresentationAsync("1A2B3C4D5E6F7G8H9I0J");

// Chỉnh sửa bài thuyết trình nếu cần (ví dụ, xóa slide thứ hai)
pres.Slides.RemoveAt(1);

// Lưu bài thuyết trình cục bộ dưới dạng tệp PDF
pres.Save(@"GoogleDriveDownload.pdf", SaveFormat.Pdf);
```

Để tiện lợi, Aspose.Slides SaaS Integration cung cấp một phương thức để liệt kê tất cả các tệp có sẵn cho người dùng. Dữ liệu trả về bao gồm tên tệp, loại MIME và ID tệp.

```csharp
// Lấy danh sách các tệp khả dụng cho tài khoản dịch vụ đã cung cấp
var availableFiles = await googleSlidesIntegration.GetDriveFileInfosAsync();

foreach (GoogleDriveFileInfo googleDriveFileInfo in availableFiles)
{
    Console.WriteLine($"File name: {googleDriveFileInfo.Name}, File ID: {googleDriveFileInfo.Id}, MIME type: {googleDriveFileInfo.MimeType}");
}
```

Một cách khác để tìm ID tệp là mở bài thuyết trình trong ứng dụng web Google Slides và tìm nó trong URL.

Ví dụ, trong URL sau:

```
https://docs.google.com/presentation/d/1A2B3C4D5E6F7G8H9I0J/edit
```

ID tệp là:

```
1A2B3C4D5E6F7G8H9I0J
```

## **Ví dụ 2**
Trong ví dụ tiếp theo, chúng ta sẽ tạo một bài thuyết trình PowerPoint từ đầu và tải lên Google Drive dưới dạng Google Slides. Đối với việc ủy quyền, chúng ta sẽ sử dụng OAuth 2.0.

```csharp
// Tạo HttpClient được quản lý bên ngoài
HttpClient httpClient = new HttpClient();

// Tạo nhà cung cấp ủy quyền bằng OAuth với client ID và client secret
IGoogleAuthorizationProvider account = new GoogleOAuthProvider("clientId", "clientSecret", httpClient);

// Khởi tạo dịch vụ tích hợp Google Slides với nhà cung cấp ủy quyền
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Create a sample presentation
using (var presentation = new Presentation())
{
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";
    
    // Lưu bài thuyết trình vào thư mục gốc Google Drive dưới định dạng Google Slides
    // Bạn cũng có thể chọn bất kỳ định dạng xuất nào khác được Aspose.Slides hỗ trợ
    var newFileId = await googleSlidesIntegration.SavePresentationAsync(presentation, "New presentation", GoogleSaveFormatType.GoogleSlides);
    Console.WriteLine($"Uploaded file ID: {newFileId}");
}
```

Nếu bạn sử dụng kiểu ủy quyền này trong ứng dụng của mình, `interaction with the browser is required`. Bạn sẽ cần chọn tài khoản và xác nhận rằng bạn cho phép ứng dụng truy cập API Google Drive của mình. Hết rồi—hoạt động này chỉ cần thực hiện trong lần chạy đầu tiên.

### **Ví dụ 3**
Trong ví dụ sau chúng ta sẽ sử dụng token truy cập đã có trước. `GoogleAccessTokenAuthProvider` là một triển khai của giao diện `IGoogleAuthorizationProvider` sử dụng token truy cập OAuth 2.0 hiện có để ủy quyền các yêu cầu tới Google API. Khác với các nhà cung cấp khởi tạo hoặc quản lý luồng OAuth, lớp này phụ thuộc vào gọi hàm để cung cấp token truy cập hợp lệ.

Nhà cung cấp này hữu ích trong các hệ thống mà token truy cập được lấy từ bên ngoài—thường là bởi một ứng dụng front‑end hoặc dịch vụ khác—và được truyền cho back‑end. Nó đặc biệt phù hợp cho môi trường phân tán, nơi việc quản lý token làm mới phía máy chủ gây ra phức tạp hoặc rủi ro token bị vô hiệu do các cố gắng làm mới đồng thời.

Ví dụ này minh họa cách thay thế một tệp và cập nhật tên của nó trên Google Drive trong khi giữ nguyên ID tệp.

```csharp
// Tạo một HttpClient để thực hiện các yêu cầu
using HttpClient httpClient = new HttpClient();

// Thiết lập xác thực Google Drive bằng token truy cập
GoogleAccessTokenAuthProvider accessTokenAuthProvider = new GoogleAccessTokenAuthProvider("access_token");

// Khởi tạo tích hợp với Google Slides/Drive bằng xác thực và HttpClient
GoogleSlidesIntegration googleSlidesIntegration =
    new GoogleSlidesIntegration(accessTokenAuthProvider, httpClient);

// Create a sample presentation using Aspose.Slides
using (var presentation = new Presentation())
{
    // Thêm hình chữ nhật vào slide đầu tiên và đặt văn bản cho nó
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";

    // Định nghĩa tùy chọn lưu PDF với chất lượng và cài đặt tuân thủ cụ thể
    ISaveOptions saveOptions = new PdfOptions()
    {
        JpegQuality = 50,
        Compliance = PdfCompliance.PdfA1b
    };

    // Lưu (thay thế) tệp hiện có trên Google Drive bằng ID tệp, cập nhật tên và xuất ra PDF
    await googleSlidesIntegration.SavePresentationToExistingFileAsync(
        presentation,
        "1A2B3C4D5E6F7G8H9I0J",            // ID của tệp hiện có trên Google Drive
        GoogleSaveFormatType.Pdf,         // Định dạng mong muốn để lưu
        saveOptions,           
        "NewFileName.pdf"                 // Tên mới sẽ gán cho tệp
    );
}
```

## **Tóm tắt**
Aspose.Slides hiện hỗ trợ một định dạng tệp bổ sung cho việc quản lý, đơn giản hoá việc tự động hoá các quy trình làm việc dựa trên đám mây để tạo, chia sẻ và chỉnh sửa bài thuyết trình.

Bài viết này đã đề cập đến các tính năng cơ bản. Bạn cũng có thể lưu tệp vào các thư mục con, thay thế tệp hiện có và xuất ra Google Drive ở nhiều định dạng khác nhau—không chỉ giới hạn ở bài thuyết trình Google Slides.

Aspose.Slides SaaS Integration sẽ tiếp tục mở rộng hỗ trợ cho các nền tảng SaaS trình bày, vì vậy hãy quay lại để cập nhật các tính năng mới trong tương lai.

## **Câu hỏi thường gặp**

**Tôi có cần tài khoản Google Workspace để sử dụng tích hợp này không?**  
Không. Bạn có thể dùng tài khoản Google miễn phí hoặc tài khoản Google Workspace. Quyền truy cập cần thiết phụ thuộc vào quyền của bạn trên Google Drive và Slides.

**Tôi nên chọn phương thức xác thực nào—Service Account hay OAuth 2.0?**  
Sử dụng **Service Account** cho các quy trình backend hoặc tự động không có tương tác người dùng.  
Sử dụng **OAuth 2.0** nếu bạn cần truy cập các tệp Google Slides hoặc Drive của người dùng cụ thể với sự đồng ý của họ.

**Tôi có thể làm việc với các định dạng khác ngoài Google Slides không?**  
Có. Aspose.Slides cho phép lưu bài thuyết trình sang nhiều định dạng (ví dụ: PDF, PPTX, HTML) trước khi tải lên Google Drive.

**Làm sao để lấy ID tệp của một bài thuyết trình Google Slides?**  
Bạn có thể lấy nó bằng phương thức `GetDriveFileInfosAsync()` hoặc sao chép từ URL của bài thuyết trình trong Google Slides.

**Tích hợp có hỗ trợ thay thế tệp đã tồn tại trên Google Drive không?**  
Có. Sử dụng phương thức `SavePresentationToExistingFileAsync` để cập nhật tệp trong khi giữ nguyên ID tệp.

**Có cần tương tác với trình duyệt mỗi lần sử dụng OAuth 2.0 không?**  
Không. Tương tác với trình duyệt chỉ cần thiết trong lần ủy quyền đầu tiên. Sau đó, token làm mới đã lưu cho phép truy cập tự động.