---
title: Hợp nhất các bản trình bày trong PHP một cách hiệu quả
linktitle: Hợp nhất bản trình bày
type: docs
weight: 40
url: /vi/php-java/merge-presentation/
keywords:
- hợp nhất PowerPoint
- hợp nhất bản trình bày
- hợp nhất slide
- hợp nhất PPT
- hợp nhất PPTX
- hợp nhất ODP
- kết hợp PowerPoint
- kết hợp bản trình bày
- kết hợp slide
- kết hợp PPT
- kết hợp PPTX
- kết hợp ODP
- PHP
- Aspose.Slides
description: "Tìm hiểu cách hợp nhất các bản trình bày PowerPoint và OpenDocument trong PHP bằng cách sao chép slide, kiểm soát master và layout, thay đổi kích thước nội dung slide, bảo lưu các section và xử lý các tệp được bảo vệ hoặc có kích thước lớn."
---
## **Tổng quan**

Aspose.Slides for PHP via Java hợp nhất các bản trình bày bằng cách sao chép các slide từ một [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) sang bản trình bày khác. Hoạt động chính là [SlideCollection::addClone()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/addclone/), có thể giữ nguyên định dạng của slide nguồn hoặc gắn slide đã sao chép vào một master hoặc layout trong bản trình bày đích.

Bài viết này bao gồm các quy trình hợp nhất phổ biến nhất:

- hợp nhất tất cả các slide đồng thời giữ nguyên định dạng nguồn;
- hợp nhất các slide được chọn;
- áp dụng master từ bản trình bày đích;
- áp dụng layout cụ thể từ bản trình bày đích;
- chuẩn hoá kích thước slide khác nhau trước khi hợp nhất;
- thêm các slide đã sao chép vào một section;
- hợp nhất nhiều bản trình bày trong một quy trình đầu‑cuối;
- xử lý master, tài nguyên, notes, comments, media, fonts, mật khẩu, tệp lớn và các vấn đề đa luồng.

## **Cách sao chép Slide ảnh hưởng tới Masters và Layouts**

Một slide kế thừa phần lớn giao diện từ layout và master của nó. Vì vậy, overload của hàm sao chép mà bạn chọn sẽ quyết định cách slide đã hợp nhất được tích hợp vào bản trình bày đích.

Sử dụng [SlideCollection::addClone()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/addclone/) bằng một trong các cách sau:

- `addClone(sourceSlide)` — giữ nguyên layout và định dạng của slide nguồn. Khi cần, master nguồn có thể được sao chép tự động vào bản trình bày đích. Aspose.Slides theo dõi các master được sao chép tự động để các slide lặp lại sử dụng cùng một master nguồn không bị sao chép lại nhiều lần.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — gắn slide đã sao chép vào một [MasterSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslide/) đích cụ thể. Aspose.Slides sẽ tìm layout phù hợp dưới master đó theo kiểu layout hoặc tên.
- `addClone(sourceSlide, destinationLayout)` — gắn slide đã sao chép trực tiếp vào một [LayoutSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/) đích cụ thể.

Master hoặc layout được truyền vào overload `addClone` phải thuộc **bản trình bày đích**, không phải bản trình bày nguồn.

## **Hợp nhất Toàn bộ Bản trình bày và Giữ Định dạng Nguồn**

Cách hợp nhất đơn giản nhất là sao chép mọi slide từ bản trình bày nguồn sang bản trình bày đích. Đây là lựa chọn phù hợp khi các slide nhập vào cần giữ nguyên theme, master và quan hệ layout gốc.

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

Kết quả có thể chứa nhiều master khi nguồn và đích sử dụng các thiết kế khác nhau. Điều này là bình thường khi định dạng nguồn được giữ cố ý.

## **Hợp nhất Các Slide Được Chọn**

Bạn không cần sao chép mọi slide. Ví dụ sau chỉ nhập các chỉ số slide được chọn từ bản trình bày nguồn.

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

Kiểm tra chỉ số slide trước khi sao chép khi chúng đến từ đầu vào của người dùng hoặc cấu hình bên ngoài.

## **Hợp nhất Slide bằng Master Đích**

Sử dụng overload [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/addclone/) khi các slide nhập vào cần tuân theo một master đã có trong bản trình bày đích.

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

Aspose.Slides sẽ chọn một layout phù hợp dưới master đã chỉ định bằng cách khớp kiểu hoặc tên của layout nguồn. Nếu không tồn tại layout thích hợp và `allowCloneMissingLayout` là `true`, layout nguồn sẽ được sao chép để slide có thể được thêm. Nếu là `false`, một [PptxEditException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxeditexception/) sẽ được ném.

Sử dụng `false` khi bạn muốn quá trình hợp nhất thất bại thay vì tạo thêm một layout vào master đích.

## **Hợp nhất Slide bằng Layout Đích Cụ Thể**

Sử dụng overload [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/addclone/) khi bạn biết chính xác layout đích mà các slide nhập vào cần sử dụng.

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

Áp dụng layout đích thay đổi quan hệ kế thừa layout; nó không thay đổi nội dung slide nguồn. Nếu layout nguồn và đích có cấu trúc placeholder khác nhau, hãy kiểm tra kết quả để xác nhận định dạng kế thừa và hành vi placeholder là phù hợp.

## **Hợp nhất Bản trình bày có Kích thước Slide Khác nhau**

Các bản trình bày có kích thước slide khác nhau có thể được hợp nhất, nhưng sao chép một slide vào bản trình bày có kích thước slide khác không tự động điều chỉnh nội dung cho canvas mới. Các shape có thể bị dịch, thay đổi tỉ lệ không mong muốn hoặc nằm ngoài vùng hiển thị.

Cách thực tế là thay đổi kích thước bản trình bày nguồn trước khi sao chép. Phương thức [SlideSize::setSize()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidesize/setsize/) có thể thu phóng nội dung hiện có trong khi thay đổi kích thước slide. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidesizescaletype/) thu phóng nội dung để vừa với kích thước yêu cầu.

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

Việc thay đổi kích thước ảnh hưởng đến đối tượng bản trình bày nguồn trong bộ nhớ. Nếu bạn cần giữ bản trình bày nguồn nguyên vẹn cho các thao tác khác, mở một phiên bản riêng cho quá trình hợp nhất.

## **Hợp nhất Slide vào Section của Bản trình bày**

Vòng lặp sao chép slide cơ bản không tái tạo lại cấu trúc section của bản trình bày nguồn. Nếu section quan trọng trong kết quả, hãy tạo hoặc chọn các section trong bản trình bày đích và sao chép slide vào chúng một cách explicit bằng [addClone(Slide, Section)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/addclone/).

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

Các slide đã sao chép sẽ được gắn vào section đích đã chỉ định. Để giữ lại nhiều section nguồn, hãy liệt kê [Presentation::getSections](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation/#getSections), lấy danh sách slide hiện tại của mỗi section nguồn bằng [Section::getSlidesListOfSection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Section/#getSlidesListOfSection), tái tạo các section trong đích, và sao chép mỗi slide trả về vào section đích tương ứng. Xem [Manage Slide Sections](/slides/vi/php-java/slide-section/) để biết ví dụ đầy đủ về liệt kê section, bao gồm cả các section rỗng và các thay đổi cấu trúc.

## **Hợp nhất Nhiều Bản trình bày một cách An toàn**

Ví dụ đầu‑cuối dưới đây sử dụng bản trình bày đầu tiên làm đích, chuẩn hoá kích thước slide của mỗi nguồn bổ sung, mở mỗi nguồn chỉ trong thời gian sao chép và lưu tệp cuối cùng một lần.

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

Đây là nền tảng hữu ích để giữ định dạng nguồn của các slide nhập vào. Nếu đầu ra của bạn phải sử dụng một theme duy nhất, thay thế lời gọi đơn giản `addClone($slide)` bằng overload master hoặc layout đích thích hợp đã đề cập ở trên.

## **Cân nhắc Thực tiễn**

### **Masters, Layouts và Độ chính xác Định dạng**

Sao chép slide mặc định có thể tự động đưa master nguồn cần thiết vào bản trình bày đích. Aspose.Slides duy trì một registry nội bộ cho các master được sao chép tự động để tránh việc sao chép lại cùng một master nhiều lần. Các master được sao chép thủ công không được registry này theo dõi, vì vậy tránh sao chép trước các master trừ khi bạn cần kiểm soát cấu trúc master một cách rõ ràng.

Đừng cho rằng hai master hoặc layout cùng tên luôn có cùng giao diện. Nếu mẫu công ty phải kiểm soát ngoại hình cuối cùng, hãy chọn master hoặc layout đích một cách rõ ràng và xác minh kết quả sau khi hợp nhất.

### **Notes và Comments**

Ghi chú người thuyết trình và comment của slide được liên kết với nội dung slide và sẽ được sao chép khi slide được sao chép. Aspose.Slides cũng cung cấp API riêng cho [presentation notes](/slides/vi/php-java/presentation-notes/) và [presentation comments](/slides/vi/php-java/presentation-comments/).

Nếu định dạng trang notes quan trọng, hãy kiểm tra bản trình bày đã hợp nhất vì master notes là đối tượng cấp độ presentation và có thể khác nhau giữa các file nguồn. Đối với quy trình xem xét, cũng cần xác minh tác giả comment và các comment dạng chuỗi sau khi kết hợp các file từ các tác giả hoặc mẫu khác nhau.

### **Hình ảnh, Audio, Video, Đối tượng OLE và Liên kết Ngoại vi**

Slide có thể tham chiếu các tài nguyên cấp presentation như hình ảnh, audio/video nhúng, và dữ liệu OLE. Hãy sao chép toàn bộ slide thay vì chỉ sao chép các shape hiển thị để Aspose.Slides có thể duy trì các mối quan hệ của slide tới tài nguyên.

Tài nguyên liên kết và tài nguyên nhúng cần được xử lý khác nhau. Một audio, video, OLE object hoặc hyperlink được liên kết vẫn phụ thuộc vào mục tiêu bên ngoài; sao chép slide không biến một liên kết ngoại vi thành nội dung nhúng. Kiểm tra đường dẫn và URL của tài nguyên liên kết trong môi trường mà bản trình bày hợp nhất sẽ được mở.

Aspose.Slides theo dõi các master được sao chép tự động, nhưng điều này không đồng nghĩa với việc các tài nguyên nhị phân giống hệt từ các bản trình bày nguồn không liên quan sẽ luôn được gộp lại. Nếu kích thước file đầu ra quan trọng, hãy kiểm tra gói đã hợp nhất và đo kết quả thay vì dựa vào việc gộp ngầm.

### **Fonts Nhúng và Tính khả dụng của Font**

Fonts được quản lý ở mức presentation. Nếu kiểu chữ phải đồng nhất trên các máy, đừng cho rằng chỉ sao chép slide sẽ bảo đảm mọi font cần thiết đã có sẵn trong môi trường đích. Bạn có thể kiểm tra fonts nhúng bằng [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/getembeddedfonts/) và quản lý việc nhúng một cách rõ ràng như mô tả trong [Embed Fonts in Presentations](/slides/vi/php-java/embedded-font/).

Cũng cần xác minh rằng bạn được phép nhúng các font được sử dụng trong các file nguồn. Giấy phép font có thể hạn chế việc nhúng.

### **Bản trình bày được Bảo mật bằng Mật khẩu**

Một nguồn được bảo mật bằng mật khẩu phải được mở thành công trước khi có thể sao chép các slide của nó. Cung cấp mật khẩu qua [LoadOptions::setPassword()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/setpassword/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // Làm việc với bản trình bày đã giải mã.
} finally {
    $source->dispose();
}
```

Mở một nguồn đã mã hoá không tự động áp dụng cùng một bảo mật cho bản trình bày đích. Cấu hình bảo mật đầu ra riêng khi cần.

### **Bản trình bày Lớn và Sử dụng Bộ nhớ**

Các bản trình bày lớn chứa hình ảnh độ phân giải cao, audio, video hoặc các đối tượng nhị phân lớn khác có thể tiêu tốn đáng kể bộ nhớ. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) cung cấp các tùy chọn kiểm soát việc xử lý BLOB và sử dụng file tạm. Xem [Open Presentations](/slides/vi/php-java/open-presentation/#open-large-presentations) để biết ví dụ PHP via Java cho tệp lớn.

Đối với tệp lớn, ưu tiên tải từ đường dẫn file khi có thể, giải phóng (dispose) mỗi bản trình bày nguồn ngay sau khi đã hợp nhất, và tránh lưu kết quả trung gian nhiều lần trừ khi quy trình yêu cầu checkpoint.

### **An toàn Đa luồng**

Đừng tải, sửa, lưu hoặc sao chép các thể hiện [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) trong nhiều luồng đồng thời. Các thao tác này không được hỗ trợ cho đa luồng trong PHP via Java. Nếu cần thực hiện các công việc hợp nhất song song, hãy chạy chúng trong các tiến trình đơn luồng riêng biệt, mỗi tiến trình sử dụng các thể hiện presentation riêng, và tuân thủ hướng dẫn [Aspose.Slides multithreading](/slides/vi/php-java/multithreading/).

## **Câu hỏi thường gặp**

**Làm sao để giữ nguyên thiết kế gốc của mỗi bản trình bày nguồn?**

Sử dụng [SlideCollection::addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/addclone/) mà không cung cấp master hoặc layout đích. Aspose.Slides có thể tự động sao chép master nguồn khi slide nhập vào cần tới nó.

**Làm sao để các slide nhập vào sử dụng theme của đích?**

Sử dụng overload nhận một master đích. Cung cấp một master từ bản trình bày đích, không phải từ nguồn. Aspose.Slides sẽ cố gắng ánh xạ mỗi slide nguồn tới một layout thích hợp dưới master đó.

**Khi nào nên dùng layout đích cụ thể thay vì master đích?**

Dùng layout cụ thể khi mọi slide nhập vào phải sử dụng cùng một layout đã biết. Dùng master khi bạn muốn Aspose.Slides tự động chọn layout trong master dựa trên kiểu hoặc tên layout nguồn.

**Có thể hợp nhất các bản trình bày có kích thước slide khác nhau không?**

Có, nhưng nội dung slide sẽ không được tự động thiết kế lại cho kích thước đích. Hãy thay đổi kích thước bản trình bày nguồn trước khi sao chép, ví dụ bằng [SlideSize::setSize()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidesize/setsize/) và [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidesizescaletype/).

**Có thể hợp nhất PPT, PPTX và ODP thành một file không?**

Có. Tải mỗi bản trình bày nguồn, sao chép các slide cần thiết vào một bản trình bày đích, và lưu bản đích ở định dạng đầu ra được hỗ trợ. Vì các định dạng presentation không hỗ trợ đầy đủ cùng một bộ tính năng, hãy xác minh nội dung phức tạp sau khi hợp nhất đa định dạng. Xem [Supported File Formats](/slides/vi/php-java/supported-file-formats/).

**Các section nguồn có được bảo lưu tự động không?**

Không, khi chỉ dùng vòng lặp cơ bản sao chép slide. Hãy tạo lại các section cần thiết trong đích và dùng overload section của [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/addclone/) khi cần bảo lưu cấu trúc section.

**Speaker notes và comments có được bảo lưu không?**

Chúng được sao chép cùng với slide đã sao chép. Đối với quy trình phụ thuộc vào định dạng notes‑master, tác giả comment hoặc dữ liệu review dạng chuỗi, hãy xác minh kết quả hợp nhất vì các trường hợp này liên quan tới cấu trúc cấp presentation cũng như nội dung slide.

**Audio, video, OLE objects và hyperlinks sẽ như thế nào?**

Nội dung nhúng sẽ được mang theo như một phần của các mối quan hệ tài nguyên của slide đã sao chép. Các liên kết ngoại vi vẫn giữ nguyên ngoại vi, vì vậy các tệp hoặc URL mục tiêu phải còn tồn tại sau khi hợp nhất.

**Fonts nhúng từ mọi nguồn có được đảm bảo có trong bản trình bày hợp nhất không?**

Không nên dựa chỉ vào sao chép slide để triển khai font. Kiểm tra các fonts nhúng trong bản đích và quản lý việc nhúng hoặc tính khả dụng font bên ngoài một cách rõ ràng khi kiểu chữ quan trọng.

**Làm sao để hợp nhất một file được bảo mật bằng mật khẩu?**

Mở nó bằng [LoadOptions::setPassword()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/setpassword/) đúng, sau đó sao chép các slide như bình thường. Bảo mật đầu ra được cấu hình riêng.

**Cần xử lý các bản trình bày rất lớn như thế nào?**

Sử dụng quản lý BLOB khi các đối tượng nhị phân lớn chi phối việc sử dụng bộ nhớ, ưu tiên tải từ đường dẫn file cho các tệp rất lớn, giải phóng (dispose) các bản trình bày nguồn kịp thời, và lưu kết quả cuối cùng chỉ khi cần.

**Có thể hợp nhất slide từ nhiều luồng không?**

Việc tải, lưu hoặc sao chép các presentation trong nhiều luồng không được hỗ trợ trong PHP via Java. Đối với công việc song song, hãy sử dụng các tiến trình đơn luồng riêng biệt và giữ các thể hiện presentation cách ly trong mỗi tiến trình.