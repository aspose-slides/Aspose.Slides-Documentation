---
title: Quản lý các phần slide trong bản trình chiếu bằng JavaScript
linktitle: Phần Slide
type: docs
weight: 90
url: /vi/nodejs-java/slide-section/
keywords:
- tạo phần
- thêm phần
- chỉnh sửa phần
- đổi tên phần
- tên phần
- lấy slide của phần
- xử lý slide của phần
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý các phần slide với Aspose.Slides cho Node.js qua Java: tạo, đổi tên, sắp xếp lại, lấy và xử lý slide của phần trong các bản trình bày PPTX."
---
## **Giới thiệu**

Các phần tổ chức các slide liên tiếp thành các nhóm có tên mà không thay đổi nội dung slide. Với Aspose.Slides for Node.js via Java, bạn có thể tạo, sắp xếp lại, đổi tên, kiểm tra và xóa các phần thông qua phương thức [Presentation.getSections](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getSections).

Các phần đặc biệt hữu ích khi:

- một bản trình bày lớn cần được chia thành các chủ đề hoặc chương logic;
- các nhóm slide khác nhau được giao cho các cộng tác viên khác nhau;
- các slide cần được xử lý, di chuyển hoặc gộp lại thành các nhóm.

Chọn tên phần ngắn gọn mô tả mục đích của các slide được nhóm lại. Vì các phần là một phần của cấu trúc bản trình bày, hãy sử dụng API phần để xác định thành viên thay vì suy ra từ vị trí slide.

## **Tạo và Quản lý Các Phần**

Sử dụng [SectionCollection.addSection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sectioncollection/#addSection) để tạo một phần bằng cách chỉ định tên và slide bắt đầu. Aspose.Slides xác định slide nào thuộc về phần dựa trên cấu trúc phần hiện tại của bản trình bày.

[SectionCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sectioncollection/) tương tự còn cho phép bạn:

- di chuyển một phần cùng với các slide của nó bằng cách sử dụng [SectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sectioncollection/#reorderSectionWithSlides);
- xóa chỉ định nghĩa phần bằng [SectionCollection.removeSection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sectioncollection/#removeSection), vẫn giữ lại các slide của nó;
- xóa một phần và các slide của nó bằng [SectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sectioncollection/#removeSectionWithSlides);
- thêm một phần rỗng vào cuối bằng [SectionCollection.appendEmptySection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sectioncollection/#appendEmptySection).

Ví dụ sau tạo hai phần, di chuyển một trong số chúng, xóa nó cùng với các slide và thêm một phần rỗng:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const titleSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    const resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Sau các thao tác này, bản trình bày chứa phần `Introduction` với các slide của nó và một phần `Appendix` rỗng. Phần `Results` và các slide của nó đã được xóa.

## **Đổi tên các Phần**

Để đổi tên một phần, gọi phương thức [Section.setName](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/section/#setName) của nó. Các slide và vị trí của phần không thay đổi.

Ví dụ sau tạo một phần và thay đổi tên của nó:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Lấy các Slide từ Các Phần**

Phương thức [Presentation.getSections](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getSections) trả về một [SectionCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sectioncollection/) mà bạn có thể truy cập theo chỉ mục. Đối với mỗi [Section](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/section/), gọi [Section.getSlidesListOfSection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/section/#getSlidesListOfSection) để lấy các slide hiện đang thuộc về nó. Phương thức này trả về một [SectionSlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sectionslidecollection/), cung cấp số lượng và truy cập theo chỉ mục.

Ví dụ sau tạo hai phần đã được điền nội dung và một phần rỗng, sau đó in ra mỗi phần [name](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/section/#getName), [identifier](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/section/#getSectionId), [starting slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/section/#getStartedFromSlide), số slide và số thứ tự slide. Nó sử dụng [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sectionslidecollection/#get_Item) để đọc cả slide đầu tiên và mọi slide trong bộ sưu tập. Đối với phần rỗng, bộ sưu tập trả về có kích thước bằng không, truy cập theo chỉ mục bị bỏ qua và vòng lặp không thực hiện thao tác nào.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    const sections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < sections.size(); sectionIndex++) {
        const section = sections.get_Item(sectionIndex);
        const sectionSlides = section.getSlidesListOfSection();
        const startingSlideObject = section.getStartedFromSlide();
        const startingSlide = startingSlideObject === null ? "none" : startingSlideObject.getSlideNumber().toString();

        console.log("Section: " + section.getName());
        console.log("ID: " + section.getSectionId().toString());
        console.log("Starting slide: " + startingSlide);
        console.log("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            console.log("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        let slideNumbers = "Slide numbers:";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            slideNumbers += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(slideNumbers);
    }
} finally {
    presentation.dispose();
}
```

Thành viên của phần được xác định bởi cấu trúc phần của bản trình bày. Đừng tính toán phạm vi của một phần một cách thủ công dựa trên [Section.getStartedFromSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/section/#getStartedFromSlide), chỉ mục slide và slide bắt đầu của phần tiếp theo.

Các chỉnh sửa cấu trúc có thể thay đổi cả các slide được trả về cho một phần và số thứ tự slide của chúng. Điều này bao gồm việc sắp xếp lại slide, sao chép một slide vào một phần, di chuyển một phần cùng với các slide của nó, xóa slide và xóa phần. Ví dụ tiếp theo gọi [Section.getSlidesListOfSection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/section/#getSlidesListOfSection) sau mỗi thay đổi như vậy thay vì giữ giả định về giới hạn cũ của phần.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const firstSection = presentation.getSections().addSection("First", firstSlide);
    const secondSection = presentation.getSections().addSection("Second", thirdSlide);

    const printSectionSlides = (label, section) => {
        const sectionSlides = section.getSlidesListOfSection();
        let output = label + " (" + sectionSlides.size() + " slides):";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            output += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(output);
    };

    printSectionSlides("Initially", firstSection);

    const slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides("After cloning into the section", firstSection);

    const slidesBeforeReorder = firstSection.getSlidesListOfSection();
    const firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    const lastSlideInSection = slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1);
    presentation.getSlides().reorder(firstSectionPosition, lastSlideInSection);
    printSectionSlides("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides("After moving the section", firstSection);

    const slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    const remainingSections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < remainingSections.size(); sectionIndex++) {
        printSectionSlides("Remaining section", remainingSections.get_Item(sectionIndex));
    }
} finally {
    presentation.dispose();
}
```

Gọi lại [Section.getSlidesListOfSection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/section/#getSlidesListOfSection) mỗi khi slide hoặc phần được sắp xếp lại, sao chép, di chuyển hoặc xóa. Điều này giúp việc xử lý tiếp theo đồng bộ với cấu trúc bản trình bày hiện tại.

Định dạng PPT (PowerPoint 97–2003) không giữ lại siêu dữ liệu phần. Hãy sử dụng quy trình này với định dạng hỗ trợ phần, chẳng hạn như PPTX; việc chuyển đổi sang PPT sẽ xóa cấu trúc phần cần thiết cho các lần lặp sau.

## **Câu hỏi thường gặp**

**Các phần có được giữ lại khi lưu dưới định dạng PPT (PowerPoint 97–2003) không?**

Không. Định dạng PPT không hỗ trợ siêu dữ liệu phần, do đó việc nhóm phần sẽ bị mất khi lưu dưới dạng .ppt.

**Có thể ẩn toàn bộ một phần không?**

Không. Một phần không có trạng thái hiển thị. Để ẩn nội dung của nó, hãy gọi [Slide.setHidden](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/#setHidden) cho mỗi slide trong phần.

**Làm thế nào để tôi tìm phần chứa một slide?**

Truy cập từng phần trong bộ sưu tập trả về bởi [Presentation.getSections](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getSections), gọi [Section.getSlidesListOfSection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/section/#getSlidesListOfSection) cho mỗi phần, và so sánh các slide trả về với slide mục tiêu. Đối với phần không rỗng, [Section.getStartedFromSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/section/#getStartedFromSlide) trả về slide đầu tiên; đối với phần rỗng, nó trả về `null`.