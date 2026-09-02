---
title: Quản lý Nhãn Nhạy cảm trong Bản trình bày PowerPoint bằng PHP
linktitle: Nhãn Nhạy cảm
type: docs
weight: 50
url: /vi/php-java/sensitivity-labels/
keywords:
- nhãn nhạy cảm
- Microsoft Purview
- Microsoft Information Protection
- siêu dữ liệu MIP
- đánh dấu nội dung
- bảo vệ thông tin
- quản trị tài liệu
- PowerPoint
- PPTX
- bảo mật bản trình bày
- PHP
- Aspose.Slides
description: "Đọc, thêm, cập nhật, xóa và di chuyển nhãn nhạy cảm Microsoft Purview trong các bản trình bày PowerPoint PPTX bằng PHP."
---
## **Tổng quan**

Nhãn nhạy cảm Microsoft Purview giúp tổ chức phân loại và quản lý tài liệu. Trong quá trình xử lý bản trình bày tự động, một ứng dụng có thể cần giữ nguyên nhãn hiện có, áp dụng nhãn được chọn theo chính sách, cập nhật trạng thái của nó, hoặc di chuyển siêu dữ liệu nhãn được ghi bởi quy trình Microsoft Information Protection (MIP) cũ hơn.

Aspose.Slides cho PHP thông qua Java cung cấp siêu dữ liệu nhãn nhạy cảm hiện đại thông qua [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getSensitivityLabels). Phương thức này trả về một [SensitivityLabelCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabelcollection/) có thể được kiểm tra và sửa đổi trước khi lưu bản trình bày dưới dạng PPTX.

{{% alert color="primary" title="Lưu ý" %}}

Các định danh nhãn nhạy cảm và thông tin chính sách được xác định bởi cấu hình Microsoft Purview của bạn. Xác thực tính khả dụng của nhãn và yêu cầu chính sách trong môi trường của bạn trước khi thêm hoặc di chuyển siêu dữ liệu. Các giá trị [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) mô tả các đánh dấu nội dung liên quan tới nhãn; chúng không tự động tạo văn bản hoặc hình dạng hiển thị trên các slide.

{{% /alert %}}

## **Hiểu các thuộc tính của Nhãn Nhạy cảm**

Mỗi [SensitivityLabel](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabel/) chứa các siêu dữ liệu sau:

| Phương thức | Mục đích |
| --- | --- |
| [SensitivityLabel::getId](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabel/#getId) và [SensitivityLabel::setId](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabel/#setId) | Lấy hoặc đặt định danh nhãn nhạy cảm trong chính sách Purview. |
| [SensitivityLabel::getSiteId](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabel/#getSiteId) và [SensitivityLabel::setSiteId](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabel/#setSiteId) | Lấy hoặc đặt trang web liên quan tới chính sách nhãn. |
| [SensitivityLabel::isEnabled](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabel/#isEnabled) và [SensitivityLabel::setEnabled](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabel/#setEnabled) | Lấy hoặc đặt trạng thái bật của nhãn. |
| [SensitivityLabel::isRemoved](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabel/#isRemoved) và [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabel/#setRemoved) | Lấy hoặc đặt trạng thái đã xóa của nhãn. Đặt giá trị thành `true` khi trạng thái xóa phải được giữ lại trong siêu dữ liệu. |
| [SensitivityLabel::getAssignmentMethodType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) và [SensitivityLabel::setAssignmentMethodType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Lấy hoặc đặt cách nhãn được áp dụng: tự động hay qua quyết định người dùng. |
| [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Lấy các loại đánh dấu nội dung liên quan tới nhãn. |

Lớp [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabelassignmenttype/) xác định cách nhãn được gán:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabelassignmenttype/) đại diện cho nhãn mặc định hoặc được áp dụng tự động.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabelassignmenttype/) đại diện cho nhãn được áp dụng qua quyết định người dùng, bao gồm các nhãn được áp dụng thủ công, đề xuất và bắt buộc.

Lớp [SensitivityLabelContentType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabelcontenttype/) định nghĩa loại đánh dấu liên quan tới nhãn:

| Giá trị | Ý nghĩa |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabelcontenttype/) | Nhãn được áp dụng mặc định hoặc tự động. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabelcontenttype/) | Đánh dấu nội dung tiêu đề được liên kết với nhãn. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabelcontenttype/) | Đánh dấu nội dung chân trang được liên kết với nhãn. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabelcontenttype/) | Đánh dấu nội dung watermark được liên kết với nhãn. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabelcontenttype/) | Bảo vệ mã hoá được liên kết với nhãn. |

Nhiều loại đánh dấu có thể được liên kết với một nhãn.

## **Liệt kê các Nhãn Nhạy cảm hiện có**

Đọc bộ sưu tập nhãn hiện đại từ [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getSensitivityLabels) và liệt kê chúng. Ví dụ sau liệt kê mọi thuộc tính và đánh dấu nội dung được lưu cho mỗi nhãn:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);

        echo "Label ID: " . java_values($sensitivityLabel->getId()) . PHP_EOL;
        echo "Site ID: " . java_values($sensitivityLabel->getSiteId()->toString()) . PHP_EOL;
        echo "Enabled: " . (java_values($sensitivityLabel->isEnabled()) ? "true" : "false") . PHP_EOL;
        echo "Removed: " . (java_values($sensitivityLabel->isRemoved()) ? "true" : "false") . PHP_EOL;
        echo "Assignment method: " . java_values($sensitivityLabel->getAssignmentMethodType()) . PHP_EOL;

        $contentMarkIterator = $sensitivityLabel->getContentMarkTypes()->iterator();
        while (java_values($contentMarkIterator->hasNext())) {
            $contentMarkType = java_values($contentMarkIterator->next());
            echo "Content marking: " . $contentMarkType . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Thêm Nhãn Nhạy cảm với Đánh dấu Nội dung**

Sử dụng [SensitivityLabelCollection::add](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabelcollection/#add) với định danh nhãn, định danh trang, trạng thái bật và phương thức gán. Khi phương thức trả về đối tượng [SensitivityLabel](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabel/) mới, thêm các giá trị đánh dấu cần thiết qua danh sách trả về bởi [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

Ví dụ sau thêm một nhãn được chọn thủ công, liên kết với các đánh dấu chân trang và watermark, sau đó lưu kết quả dưới dạng PPTX:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();

    $labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $UUID = new JavaClass("java.util.UUID");
    $siteIdentifier = $UUID->fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    $isEnabled = true;
    $assignmentMethod = SensitivityLabelAssignmentType::Privileged;

    $sensitivityLabel = $sensitivityLabels->add(
        $labelIdentifier,
        $siteIdentifier,
        $isEnabled,
        $assignmentMethod
    );

    $contentMarkTypes = $sensitivityLabel->getContentMarkTypes();
    $contentMarkTypes->addItem(SensitivityLabelContentType::Footer);
    $contentMarkTypes->addItem(SensitivityLabelContentType::Watermark);

    $presentation->save("presentation_with_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Cập nhật Nhãn Nhạy cảm**

Các giá trị của [SensitivityLabel](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabel/) có thể đọc/ghi, ngoại trừ danh sách trả về bởi [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) được sửa đổi thông qua các thao tác danh sách. Sau khi xác định nhãn cần thiết, bạn có thể cập nhật định danh, định danh trang, trạng thái bật, phương thức gán, trạng thái xóa và các loại đánh dấu nội dung. Lưu bản trình bày để ghi lại các thay đổi.

Ví dụ sau cập nhật trạng thái bật và phương thức gán của nhãn đầu tiên:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    if ($sensitivityLabelCount > 0) {
        $sensitivityLabel = $sensitivityLabels->get_Item(0);
        $sensitivityLabel->setEnabled(true);
        $sensitivityLabel->setAssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
    }

    $presentation->save("presentation_with_updated_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đánh dấu Nhãn Nhạy cảm là Đã Xóa**

Để giữ lại thông tin rằng một nhãn đã bị xóa, tìm nhãn và gọi [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabel/#setRemoved) với `true`. Thao tác này giữ lại mục nhãn đồng thời ghi lại trạng thái đã xóa. Nếu bạn muốn xóa mục khỏi bộ sưu tập hiện đại, hãy sử dụng [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabelcollection/#removeAt); sử dụng [SensitivityLabelCollection::clear](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabelcollection/#clear) để xóa mọi mục.

Ví dụ sau đánh dấu một nhãn cụ thể là đã xóa và lưu bản trình bày đã cập nhật:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);
        $labelIdentifier = java_values($sensitivityLabel->getId());
        $isTargetLabel = strcasecmp($labelIdentifier, $targetLabelIdentifier) === 0;

        if ($isTargetLabel) {
            $sensitivityLabel->setRemoved(true);
            break;
        }
    }

    $presentation->save("presentation_with_removed_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đọc và Di chuyển Nhãn Nhạy cảm Legacy MIP**

Các quy trình dựa trên MIP cũ có thể lưu siêu dữ liệu nhãn nhạy cảm trong thuộc tính tài liệu tùy chỉnh thay vì bộ sưu tập nhãn hiện đại. Đọc siêu dữ liệu đó bằng [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/#getSensitivityLabels). Phương thức này phân tích các thuộc tính tùy chỉnh legacy và trả về một mảng Java các đối tượng [SensitivityLabel](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabel/).

Để di chuyển siêu dữ liệu, thêm từng nhãn đã trả về vào [SensitivityLabelCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabelcollection/) hiện đại thông qua [SensitivityLabelCollection::add](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabelcollection/#add). Vì việc thêm nhãn có định danh trùng lặp sẽ gây ngoại lệ, ví dụ kiểm tra bộ sưu tập đích trước khi sao chép mỗi nhãn. Bạn có thể thêm xác thực bổ sung để xác nhận mỗi nhãn legacy vẫn tồn tại trong chính sách Purview hiện tại.

```php
$presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    $legacySensitivityLabels = $presentation->getDocumentProperties()->getSensitivityLabels();
    $modernSensitivityLabels = $presentation->getSensitivityLabels();

    $Array = new JavaClass("java.lang.reflect.Array");
    $legacyLabelCount = java_values($Array->getLength($legacySensitivityLabels));

    for ($legacyLabelIndex = 0; $legacyLabelIndex < $legacyLabelCount; $legacyLabelIndex++) {
        $legacySensitivityLabel = $legacySensitivityLabels[$legacyLabelIndex];
        $legacyLabelIdentifier = java_values($legacySensitivityLabel->getId());
        $labelAlreadyExists = false;
        $modernLabelCount = java_values($modernSensitivityLabels->getCount());

        for ($modernLabelIndex = 0; $modernLabelIndex < $modernLabelCount; $modernLabelIndex++) {
            $modernSensitivityLabel = $modernSensitivityLabels->get_Item($modernLabelIndex);
            $modernLabelIdentifier = java_values($modernSensitivityLabel->getId());
            $labelAlreadyExists = strcasecmp(
                $modernLabelIdentifier,
                $legacyLabelIdentifier
            ) === 0;

            if ($labelAlreadyExists) {
                break;
            }
        }

        if (!$labelAlreadyExists) {
            $modernSensitivityLabels->add($legacySensitivityLabel);
        }
    }

    $presentation->save("presentation_with_modern_labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Quá trình di chuyển sao chép các đối tượng nhãn đã phân tích vào bộ sưu tập hiện đại. Nó không yêu cầu xóa toàn bộ thuộc tính tài liệu tùy chỉnh, do đó các siêu dữ liệu tài liệu không liên quan vẫn được bảo toàn. Sử dụng [Presentation::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#save) cùng với [SaveFormat::Pptx](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveformat/) để ghi siêu dữ liệu nhãn hiện đại vào tệp PPTX.

## **Câu hỏi thường gặp**

**Việc thêm loại đánh dấu nội dung có tạo tiêu đề, chân trang hoặc watermark hiển thị trên slide không?**

Không. Các giá trị được thêm qua danh sách trả về bởi [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) chỉ mô tả các đánh dấu liên quan tới nhãn nhạy cảm. Chúng không tạo ra văn bản hoặc hình dạng hiển thị trong bản trình bày. Bạn cần thêm nội dung slide tương ứng riêng biệt nếu quy trình của mình phải hiển thị các đánh dấu này.

**Sự khác biệt giữa việc đánh dấu một nhãn là đã xóa và xóa nó khỏi bộ sưu tập là gì?**

Gọi [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabel/#setRemoved) với `true` giữ lại mục nhãn và ghi lại trạng thái đã xóa. Gọi [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) xóa mục khỏi bộ sưu tập hiện đại. Hãy chọn thao tác phù hợp với yêu cầu lưu trữ siêu dữ liệu của tổ chức bạn.

**Một bản trình bày có thể chứa cả siêu dữ liệu MIP legacy và nhãn nhạy cảm hiện đại không?**

Có. Các nhãn legacy có thể vẫn tồn tại trong thuộc tính tài liệu tùy chỉnh trong khi nhãn hiện đại được truy cập qua [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getSensitivityLabels). Sử dụng [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/#getSensitivityLabels) để đọc siêu dữ liệu legacy và di chuyển chỉ những nhãn hợp lệ chưa có trong bộ sưu tập hiện đại.

**Điều gì xảy ra khi một nhãn có cùng định danh được thêm nhiều lần?**

[SensitivityLabelCollection::add](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabelcollection/#add) ném ngoại lệ khi bộ sưu tập đã chứa nhãn có cùng định danh. Kiểm tra các giá trị hiện có trả về bởi [SensitivityLabel::getId](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sensitivitylabel/#getId) trước khi thêm hoặc di chuyển nhãn.

**Định dạng xuất nào nên dùng để giữ lại các nhãn nhạy cảm đã cập nhật?**

Lưu bản trình bày dưới dạng PPTX bằng cách gọi [Presentation::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#save) với [SaveFormat::Pptx](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveformat/), như đã minh họa trong các ví dụ ở trên.