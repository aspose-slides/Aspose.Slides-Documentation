---
title: Quản lý các phần slide trong bản trình bày trên Android
linktitle: Phần Slide
type: docs
weight: 90
url: /vi/androidjava/slide-section/
keywords:
- tạo phần
- thêm phần
- chỉnh sửa phần
- thay đổi phần
- tên phần
- lấy slide phần
- xử lý slide phần
- PowerPoint
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Quản lý các phần slide với Aspose.Slides cho Android qua Java: tạo, đổi tên, sắp xếp lại, truy xuất và xử lý các slide phần trong bản trình bày PPTX."
---
## **Giới thiệu**

Các phần tổ chức các slide liên tiếp thành các nhóm có tên mà không thay đổi nội dung slide. Với Aspose.Slides cho Android qua Java, bạn có thể tạo, sắp xếp lại, đổi tên, kiểm tra và xóa các phần thông qua phương thức [Presentation.getSections](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getSections--) .

Các phần đặc biệt hữu ích khi:

- một bản trình bày lớn cần được chia thành các chủ đề hoặc chương hợp lý;
- các nhóm slide khác nhau được giao cho các cộng tác viên khác nhau;
- slide cần được xử lý, di chuyển, hoặc hợp nhất dưới dạng nhóm.

Chọn tên phần ngắn gọn mô tả mục đích của các slide được nhóm lại. Vì các phần là một phần của cấu trúc bản trình bày, hãy sử dụng các API phần để xác định thành viên thay vì suy ra từ vị trí slide.

## **Tạo và Quản lý Các Phần**

Sử dụng [ISectionCollection.addSection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) để tạo một phần bằng cách chỉ định tên và slide bắt đầu. Aspose.Slides xác định slide nào thuộc phần dựa trên cấu trúc phần hiện tại của bản trình bày.

Cùng với [ISectionCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isectioncollection/) , bạn cũng có thể:

- di chuyển một phần cùng với các slide của nó bằng cách sử dụng [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-);
- xóa chỉ định nghĩa phần bằng [ISectionCollection.removeSection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-), giữ lại các slide của nó;
- xóa một phần và các slide của nó bằng [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-);
- thêm một phần trống ở cuối bằng [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-).

Ví dụ sau tạo hai phần, di chuyển một trong số chúng, xóa nó cùng với các slide, và thêm một phần trống:

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide titleSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    ISection resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Sau các thao tác này, bản trình bày chứa phần `Introduction` với các slide của nó và một phần `Appendix` trống. Phần `Results` và các slide của nó đã bị xóa.

## **Đổi tên Các Phần**

Để đổi tên một phần, gọi phương thức [ISection.setName](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isection/#setName-java.lang.String-) của nó. Các slide và vị trí của phần không thay đổi.

Ví dụ sau tạo một phần và thay đổi tên của nó:

```java
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISection section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Lấy các Slide từ Các Phần**

Phương thức [Presentation.getSections](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getSections--) trả về một [ISectionCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isectioncollection/) mà bạn có thể duyệt. Đối với mỗi [ISection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isection/), gọi [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) để lấy các slide hiện đang thuộc về nó. Phương thức trả về một [ISectionSlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isectionslidecollection/), cung cấp số lượng, truy cập theo chỉ mục và khả năng lặp.

Ví dụ sau tạo hai phần đã có nội dung và một phần trống, sau đó in ra [name](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isection/#getName--), [identifier](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isection/#getSectionId--), [starting slide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isection/#getStartedFromSlide--), số lượng slide và số slide của mỗi phần. Nó sử dụng [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isectionslidecollection/#get_Item-int-) để đọc slide đầu tiên và một câu lệnh `for` mở rộng để xử lý mọi slide. Đối với phần trống, bộ sưu tập trả về có kích thước bằng không, phương thức không được gọi và vòng lặp không thực hiện thao tác nào.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    for (ISection section : presentation.getSections()) {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        String startingSlide = section.getStartedFromSlide() == null ? "none" : Integer.toString(section.getStartedFromSlide().getSlideNumber());

        System.out.println("Section: " + section.getName());
        System.out.println("ID: " + section.getSectionId());
        System.out.println("Starting slide: " + startingSlide);
        System.out.println("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            System.out.println("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        System.out.print("Slide numbers:");
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

Thành viên của phần được xác định bởi cấu trúc phần của bản trình bày. Không tự tính phạm vi của một phần bằng cách sử dụng [ISection.getStartedFromSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isection/#getStartedFromSlide--), chỉ số slide và slide bắt đầu của phần tiếp theo.

Việc chỉnh sửa cấu trúc có thể thay đổi cả các slide trả về cho một phần và số thứ tự slide của chúng. Điều này bao gồm sắp xếp lại slide, sao chép một slide vào một phần, di chuyển một phần cùng với các slide, xóa slide và xóa phần. Ví dụ tiếp theo gọi [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) sau mỗi thay đổi như vậy thay vì giữ giả định về phạm vi trước của phần.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

import java.util.function.BiConsumer;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISection firstSection = presentation.getSections().addSection("First", firstSlide);
    ISection secondSection = presentation.getSections().addSection("Second", thirdSlide);

    BiConsumer<String, ISection> printSectionSlides = (label, section) -> {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        System.out.printf("%s (%d slides):", label, sectionSlides.size());
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    };

    printSectionSlides.accept("Initially", firstSection);

    ISectionSlideCollection slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides.accept("After cloning into the section", firstSection);

    ISectionSlideCollection slidesBeforeReorder = firstSection.getSlidesListOfSection();
    int firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    presentation.getSlides().reorder(firstSectionPosition, slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1));
    printSectionSlides.accept("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides.accept("After moving the section", firstSection);

    ISectionSlideCollection slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides.accept("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    for (ISection section : presentation.getSections()) {
        printSectionSlides.accept("Remaining section", section);
    }
} finally {
    presentation.dispose();
}
```

Bạn nên gọi lại [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) mỗi khi slide hoặc phần được sắp xếp lại, sao chép, di chuyển hoặc xóa. Điều này giúp quá trình xử lý tiếp theo đồng bộ với cấu trúc bản trình bày hiện tại.

Định dạng PPT (PowerPoint 97–2003) không giữ siêu dữ liệu của phần. Hãy sử dụng quy trình này với định dạng hỗ trợ phần, chẳng hạn như PPTX; chuyển đổi sang PPT sẽ xóa cấu trúc phần cần thiết cho việc lặp lại sau này.

## **Câu hỏi thường gặp**

**Các phần có được giữ lại khi lưu dưới định dạng PPT (PowerPoint 97–2003) không?**

Không. Định dạng PPT không hỗ trợ siêu dữ liệu của phần, do đó việc nhóm phần bị mất khi lưu dưới dạng .ppt.

**Có thể ẩn toàn bộ một phần không?**

Không. Một phần không có trạng thái hiển thị/ẩn. Để ẩn nội dung của nó, hãy gọi [ISlide.setHidden](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/#setHidden-boolean-) cho mỗi slide trong phần đó.

**Làm sao tôi có thể tìm phần chứa một slide?**

Duyệt qua bộ sưu tập trả về bởi [Presentation.getSections](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getSections--) , gọi [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) cho mỗi phần, và so sánh các slide trả về với slide mục tiêu. Đối với phần không rỗng, [ISection.getStartedFromSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) trả về slide đầu tiên; đối với phần rỗng, nó trả về `null`.