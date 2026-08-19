---
title: Hiệu quả hợp nhất các bản trình chiếu trong PHP
linktitle: Hợp nhất bản trình chiếu
type: docs
weight: 40
url: /vi/php-java/merge-presentation/
keywords:
- hợp nhất PowerPoint
- hợp nhất bản trình chiếu
- hợp nhất slide
- hợp nhất PPT
- hợp nhất PPTX
- hợp nhất ODP
- kết hợp PowerPoint
- kết hợp bản trình chiếu
- kết hợp slide
- kết hợp PPT
- kết hợp PPTX
- kết hợp ODP
- PHP
- Aspose.Slides
description: "Tìm hiểu cách hợp nhất các bản trình chiếu PowerPoint và OpenDocument trong PHP bằng cách sao chép slide, kiểm soát master và layout, thay đổi kích thước nội dung slide, giữ nguyên các phần, và xử lý các tệp được bảo vệ hoặc lớn."
---
## **Tổng quan**

Aspose.Slides for PHP qua Java hợp nhất các bản trình chiếu bằng cách sao chép các slide từ một [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) sang bản khác. Hoạt động chính là [SlideCollection::addClone()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/addclone/), có thể giữ nguyên định dạng của slide nguồn hoặc gắn slide đã sao chép vào một master hoặc layout trong bản trình chiếu đích.

Bài viết này đề cập đến các quy trình hợp nhất phổ biến nhất:

- hợp nhất tất cả các slide đồng thời giữ nguyên định dạng nguồn;
- hợp nhất các slide đã chọn;
- áp dụng một master từ bản trình chiếu đích;
- áp dụng một layout cụ thể từ bản trình chiếu đích;
- chuẩn hóa các kích thước slide khác nhau trước khi hợp nhất;
- thêm các slide đã sao chép vào một phần;
- hợp nhất nhiều bản trình chiếu trong một quy trình đầu‑cuối;
- xử lý master, tài nguyên, ghi chú, bình luận, đa phương tiện, phông chữ, mật khẩu, tệp lớn và các vấn đề đa luồng.

## **Cách sao chép Slide ảnh hưởng đến Master và Layouts**

Một slide kế thừa phần lớn giao diện của nó từ layout và master. Vì vậy, phương thức overload sao chép mà bạn chọn quyết định cách slide được hợp nhất sẽ được tích hợp vào bản trình chiếu đích.

Sử dụng [SlideCollection::addClone()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/addclone/) theo một trong các cách sau:

- `addClone(sourceSlide)` — giữ nguyên layout và định dạng của slide nguồn. Khi cần, master nguồn có thể được sao chép tự động vào bản trình chiếu đích. Aspose.Slides theo dõi các master được sao chép tự động để các slide lặp lại sử dụng cùng một master nguồn không bị sao chép nhiều lần.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — gắn slide đã sao chép vào một [MasterSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslide/) đích cụ thể. Aspose.Slides tìm kiếm một layout phù hợp dưới master đó dựa trên loại layout hoặc tên.
- `addClone(sourceSlide, destinationLayout)` — gắn slide đã sao chép trực tiếp vào một [LayoutSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/) đích cụ thể.

Master hoặc layout được truyền tới overload `addClone` phải thuộc về bản trình chiếu **đích**, không phải bản trình chiếu nguồn.

## **Hợp nhất toàn bộ bản trình chiếu và giữ nguyên định dạng nguồn**

Cách hợp nhất đơn giản nhất là sao chép mọi slide từ bản trình chiếu nguồn sang bản trình chiếu đích. Đây là lựa chọn phù hợp khi các slide được nhập cần giữ nguyên chủ đề, master và quan hệ layout gốc.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Bản trình chiếu kết quả có thể chứa nhiều master khi nguồn và đích sử dụng các thiết kế khác nhau. Điều này là mong đợi khi định dạng nguồn được cố ý giữ nguyên.

## **Hợp nhất các slide đã chọn**

Bạn không cần sao chép mọi slide. Ví dụ dưới đây chỉ nhập các chỉ mục slide đã chọn từ bản trình chiếu nguồn.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $slideIndexes = [0, 2, 4];

        foreach ($slideIndexes as $index) {
            $destination->getSlides()->addClone($source->getSlides()->get_Item($index));
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-selected-slides.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Xác thực các chỉ mục slide trước khi sao chép khi chúng đến từ đầu vào của người dùng hoặc cấu hình bên ngoài.

## **Hợp nhất slide bằng Master đích**

Sử dụng overload [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/addclone/) khi các slide được nhập cần tuân theo một master đã thuộc về bản trình chiếu đích.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationMaster = $destination->getMasters()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationMaster, true);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-master.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Aspose.Slides chọn một layout phù hợp dưới master đã chỉ định bằng cách khớp loại hoặc tên của layout nguồn. Nếu không có layout phù hợp và `allowCloneMissingLayout` là `true`, layout nguồn sẽ được sao chép để slide có thể được thêm. Nếu nó là `false`, một [PptxEditException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxeditexception/) sẽ được ném.

Sử dụng `false` khi bạn muốn quá trình hợp nhất thất bại thay vì tạo thêm một layout vào master đích.

## **Hợp nhất slide bằng Layout đích cụ thể**

Sử dụng overload [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/addclone/) khi bạn biết chính xác layout đích nào mà các slide được nhập nên sử dụng.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationLayout = $destination->getLayoutSlides()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationLayout);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-layout.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Áp dụng một layout đích thay đổi quan hệ layout được kế thừa; nó không thiết kế lại nội dung slide nguồn. Nếu layout nguồn và đích có cấu trúc placeholder khác nhau, hãy kiểm tra kết quả để xác nhận rằng định dạng kế thừa và hành vi placeholder là phù hợp.

## **Hợp nhất bản trình chiếu với các kích thước slide khác nhau**

Các bản trình chiếu có kích thước slide khác nhau có thể được hợp nhất, nhưng sao chép một slide vào bản trình chiếu có kích thước slide khác không tự động thiết kế lại nội dung cho canvas mới. Do đó các hình dạng có thể xuất hiện bị dịch vị, tỷ lệ không mong muốn, hoặc nằm ngoài vùng slide hiển thị.

Cách thực tế là thay đổi kích thước bản trình chiếu nguồn trước khi sao chép. Phương thức [SlideSize::setSize()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidesize/setsize/) có thể thu phóng nội dung hiện có trong khi thay đổi kích thước slide. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidesizescaletype/) thu phóng nội dung để vừa với kích thước yêu cầu.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
        $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());
        $destinationWidth = java_values($destination->getSlideSize()->getSize()->getWidth());
        $destinationHeight = java_values($destination->getSlideSize()->getSize()->getHeight());

        if ($sourceWidth != $destinationWidth || $sourceHeight != $destinationHeight) {
            $source->getSlideSize()->setSize($destinationWidth, $destinationHeight, SlideSizeScaleType::EnsureFit);
        }

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-same-slide-size.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Thay đổi kích thước sẽ thay đổi đối tượng bản trình chiếu nguồn trong bộ nhớ. Nếu bạn cần bản trình chiếu nguồn gốc không bị thay đổi cho các thao tác khác, hãy mở một thể hiện riêng cho quá trình hợp nhất.

## **Hợp nhất slide vào một phần của bản trình chiếu**

Vòng lặp sao chép slide cơ bản không tái tạo cấu trúc phần (section) của bản trình chiếu nguồn. Nếu các phần quan trọng trong kết quả, hãy tạo hoặc chọn các phần trong bản trình chiếu đích và sao chép slide vào chúng một cách rõ ràng bằng [addClone(Slide, Section)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/addclone/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $importedSection = $destination->getSections()->appendEmptySection("Imported slides");

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $importedSection);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-section.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Các slide đã sao chép sẽ được thêm vào phần đích đã chỉ định. Để giữ lại nhiều phần nguồn, hãy tạo lại các phần đó trong đích và ánh xạ mỗi slide nguồn tới phần đích tương ứng.

## **Hợp nhất nhiều bản trình chiếu một cách an toàn**

Ví dụ đầu‑cuối dưới đây sử dụng bản trình chiếu đầu tiên làm đích, chuẩn hóa kích thước slide của mỗi nguồn bổ sung, giữ mỗi nguồn mở chỉ khi đang sao chép, và lưu tệp cuối cùng một lần.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

$merged = new Presentation($inputFiles[0]);
try {
    $mergedWidth = java_values($merged->getSlideSize()->getSize()->getWidth());
    $mergedHeight = java_values($merged->getSlideSize()->getSize()->getHeight());

    for ($fileIndex = 1; $fileIndex < count($inputFiles); $fileIndex++) {
        $source = new Presentation($inputFiles[$fileIndex]);
        try {
            $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
            $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());

            if ($sourceWidth != $mergedWidth || $sourceHeight != $mergedHeight) {
                $source->getSlideSize()->setSize($mergedWidth, $mergedHeight, SlideSizeScaleType::EnsureFit);
            }

            foreach ($source->getSlides() as $slide) {
                $merged->getSlides()->addClone($slide);
            }
        } finally {
            $source->dispose();
        }
    }

    $merged->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $merged->dispose();
}
```

Đây là một nền tảng hữu ích để giữ định dạng nguồn của các slide được nhập. Nếu đầu ra của bạn phải sử dụng một chủ đề đích duy nhất, hãy thay thế lời gọi `addClone($slide)` đơn giản bằng overload master đích hoặc layout đích thích hợp đã trình bày ở trên.

## **Các cân nhắc thực tiễn**

### **Masters, Layouts, và Độ chính xác Định dạng**

Việc sao chép slide mặc định có thể tự động đưa một master nguồn cần thiết vào bản trình chiếu đích. Aspose.Slides duy trì một danh sách nội bộ cho các master được sao chép tự động nhằm tránh sao chép lại cùng một master nhiều lần. Các master được sao chép thủ công không được theo dõi bởi danh sách này, vì vậy tránh sao chép trước các master trừ khi bạn cần kiểm soát rõ ràng cấu trúc master.

Không giả định rằng hai master hoặc layout có cùng tên sẽ nhìn giống nhau. Nếu một mẫu công ty phải kiểm soát giao diện cuối cùng, hãy chọn một master hoặc layout đích một cách rõ ràng và kiểm tra kết quả sau khi hợp nhất.

### **Ghi chú và Bình luận**

Ghi chú người thuyết trình và bình luận slide được liên kết với nội dung slide và được sao chép khi slide được sao chép. Aspose.Slides cũng cung cấp các API chuyên dụng cho [presentation notes](https://docs.aspose.com/slides/vi/php-java/presentation-notes/) và [presentation comments](https://docs.aspose.com/slides/vi/php-java/presentation-comments/).

Nếu định dạng trang ghi chú quan trọng, hãy kiểm tra bản trình chiếu đã hợp nhất vì các notes master là đối tượng cấp bản trình chiếu và có thể khác nhau giữa các tệp nguồn. Đối với quy trình xem xét, cũng hãy xác thực tác giả bình luận và các bình luận dạng chuỗi sau khi kết hợp các tệp từ các tác giả hoặc mẫu khác nhau.

### **Hình ảnh, Audio, Video, Đối tượng OLE và Liên kết Ngoài**

Các slide có thể tham chiếu tới các tài nguyên cấp bản trình chiếu như hình ảnh, audio nhúng, video nhúng và dữ liệu OLE. Hãy sao chép toàn bộ slide thay vì chỉ sao chép các hình dạng hiển thị để Aspose.Slides có thể duy trì các mối quan hệ của slide với tài nguyên của nó.

Các tài nguyên nhúng và liên kết nên được xử lý riêng biệt. Một audio, video, đối tượng OLE hoặc hyperlink được liên kết vẫn phụ thuộc vào mục tiêu bên ngoài; sao chép một slide không biến một liên kết ngoài thành nội dung nhúng. Kiểm tra đường dẫn và URL của tài nguyên liên kết trong môi trường nơi bản trình chiếu hợp nhất sẽ được mở.

Aspose.Slides theo dõi một cách rõ ràng các master được sao chép tự động, nhưng điều này không nên được coi là đảm bảo chung rằng các tài nguyên nhị phân giống nhau từ các bản trình chiếu nguồn không liên quan sẽ luôn được loại bỏ trùng lặp. Nếu kích thước tệp đầu ra quan trọng, hãy kiểm tra gói hợp nhất và đo kết quả thay vì dựa vào việc loại bỏ trùng lặp ngầm.

### **Phông chữ Nhúng và Tính khả dụng của Phông chữ**

Phông chữ được quản lý ở cấp bản trình chiếu. Nếu kiểu chữ phải nhất quán trên các máy, không nên giả định rằng việc sao chép slide thôi đủ để đảm bảo mọi phông chữ cần thiết đều có sẵn trong môi trường đích. Bạn có thể kiểm tra phông chữ nhúng bằng [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/getembeddedfonts/) và quản lý việc nhúng một cách rõ ràng như mô tả trong [Embed Fonts in Presentations](https://docs.aspose.com/slides/vi/php-java/embedded-font/).

Cũng hãy xác thực rằng bạn được phép nhúng các phông chữ được sử dụng trong các tệp nguồn. Giấy phép phông chữ có thể hạn chế việc nhúng.

### **Bản trình chiếu được bảo vệ bằng mật khẩu**

Một nguồn được bảo vệ bằng mật khẩu phải được mở thành công trước khi các slide của nó có thể được sao chép. Cung cấp mật khẩu qua [LoadOptions::setPassword()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/setpassword/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // Làm việc với bản trình chiếu đã giải mã.
} finally {
    $source->dispose();
}
```

Mở một nguồn được mã hóa không tự động áp dụng cùng một mức bảo vệ cho bản trình chiếu đích. Cấu hình bảo vệ đầu ra được thực hiện riêng biệt khi cần.

### **Bản trình chiếu lớn và Sử dụng Bộ nhớ**

Các bản trình chiếu lớn chứa hình ảnh độ phân giải cao, audio, video hoặc các đối tượng nhị phân lớn khác có thể tiêu tốn đáng kể bộ nhớ. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) cung cấp các điều khiển cho việc xử lý BLOB và sử dụng tệp tạm thời. Xem [Open Presentations](https://docs.aspose.com/slides/vi/php-java/open-presentation/#open-large-presentations) để biết ví dụ tệp lớn trong PHP qua Java.

Đối với các tệp lớn, ưu tiên tải từ đường dẫn tệp khi có thể, giải phóng mỗi bản trình chiếu nguồn ngay sau khi đã hợp nhất, và tránh lưu kết quả trung gian lặp đi lặp lại trừ khi quy trình yêu cầu các điểm kiểm tra.

### **An toàn đa luồng**

Không tải, sửa đổi, lưu hoặc sao chép các thực thể [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) trong nhiều luồng. Các thao tác này không được hỗ trợ cho việc sử dụng đa luồng trong PHP qua Java. Nếu bạn cần các công việc hợp nhất song song, hãy chạy chúng trong các tiến trình đơn luồng riêng biệt, mỗi tiến trình sử dụng các thực thể bản trình chiếu riêng, và tuân theo [hướng dẫn đa luồng của Aspose.Slides](https://docs.aspose.com/slides/vi/php-java/multithreading/).

## **CÂU HỎI THƯỜNG GẶP**

**Làm thế nào để giữ nguyên thiết kế gốc của mỗi bản trình chiếu nguồn?**

Sử dụng [`addClone(sourceSlide)`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/addclone/) mà không cung cấp master hoặc layout đích. Aspose.Slides có thể tự động sao chép master nguồn khi slide được nhập cần tới.

**Làm thế nào để các slide được nhập sử dụng chủ đề đích?**

Sử dụng overload chấp nhận một master đích. Truyền một master từ bản trình chiếu đích, không phải từ nguồn. Aspose.Slides sẽ cố gắng ánh xạ mỗi slide nguồn tới một layout phù hợp dưới master đó.

**Khi nào nên sử dụng layout đích cụ thể thay vì master đích?**

Sử dụng một layout cụ thể khi mọi slide được nhập phải sử dụng một layout đã biết. Sử dụng master khi bạn muốn Aspose.Slides chọn parmi các layout của master đó dựa trên loại hoặc tên layout nguồn.

**Các bản trình chiếu có kích thước slide khác nhau có thể được hợp nhất không?**

Có, nhưng nội dung slide không tự động được thiết kế lại cho kích thước đích. Thay đổi kích thước bản trình chiếu nguồn trước khi cần vị trí dự đoán, ví dụ bằng [SlideSize::setSize()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidesize/setsize/) và [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidesizescaletype/).

**Tôi có thể hợp nhất các bản trình chiếu PPT, PPTX và ODP thành một tệp không?**

Có. Tải mỗi bản trình chiếu nguồn, sao chép các slide cần thiết vào một đích, và lưu đích ở định dạng xuất được hỗ trợ. Vì các định dạng bản trình chiếu không hỗ trợ cùng một bộ tính năng, hãy kiểm tra nội dung phức tạp sau khi hợp nhất đa định dạng. Xem [Supported File Formats](https://docs.aspose.com/slides/vi/php-java/supported-file-formats/).

**Các phần nguồn có được giữ tự động không?**

Không, với một vòng lặp cơ bản chỉ sao chép slide. Tạo lại các phần cần thiết trong đích và sử dụng overload phần của [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/addclone/) khi cấu trúc phần phải được giữ.

**Ghi chú người thuyết trình và bình luận có được giữ không?**

Chúng được sao chép cùng với slide đã sao chép. Đối với quy trình phụ thuộc vào kiểu style của notes-master, tác giả bình luận hoặc dữ liệu review dạng chuỗi, hãy kiểm tra kết quả hợp nhất vì các kịch bản này liên quan đến cấu trúc cấp bản trình chiếu cũng như nội dung cấp slide.

**Điều gì xảy ra với audio, video, đối tượng OLE và hyperlink?**

Nội dung nhúng được mang theo như một phần của các mối quan hệ tài nguyên của slide đã sao chép. Các liên kết ngoài vẫn ở ngoài, vì vậy các tệp hoặc URL mục tiêu của chúng vẫn phải khả dụng sau khi hợp nhất.

**Các phông chữ nhúng từ mọi nguồn có được đảm bảo có sẵn trong bản trình chiếu hợp nhất không?**

Không nên chỉ dựa vào việc sao chép slide để triển khai phông chữ. Kiểm tra các phông chữ nhúng của đích và quản lý việc nhúng phông chữ hoặc tính khả dụng phông chữ bên ngoài một cách rõ ràng khi kiểu chữ quan trọng.

**Làm thế nào để hợp nhất một tệp được bảo vệ bằng mật khẩu?**

Mở nó bằng [LoadOptions::setPassword()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/setpassword/) đúng, sau đó sao chép các slide bình thường. Bảo vệ đầu ra được cấu hình riêng.

**Làm thế nào để xử lý các bản trình chiếu rất lớn?**

Sử dụng quản lý BLOB khi các đối tượng nhị phân lớn chiếm ưu tiên bộ nhớ, ưu tiên tải từ đường dẫn tệp cho các tệp rất lớn, giải phóng nhanh các bản trình chiếu nguồn, và lưu kết quả cuối cùng chỉ khi cần.

**Tôi có thể hợp nhất slide từ nhiều luồng không?**

Việc tải, lưu hoặc sao chép các bản trình chiếu trong nhiều luồng không được hỗ trợ trong PHP qua Java. Đối với công việc song song, hãy sử dụng các tiến trình đơn luồng riêng biệt và giữ các thực thể bản trình chiếu cách biệt trong mỗi tiến trình.