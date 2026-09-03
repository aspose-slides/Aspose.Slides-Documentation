---
title: Nhúng phông chữ trong bản trình bày bằng Java
linktitle: Phông chữ đã nhúng
type: docs
weight: 40
url: /vi/java/embedded-font/
keywords:
- thêm phông chữ
- nhúng phông chữ
- nhúng phông chữ
- lấy phông chữ đã nhúng
- thêm phông chữ đã nhúng
- xóa phông chữ đã nhúng
- nén phông chữ đã nhúng
- PowerPoint
- bản trình bày
- Java
- Aspose.Slides
description: "Quản lý các phông chữ đã nhúng trong PowerPoint bằng Aspose.Slides cho Java. Thêm, lấy, xóa và nén phông chữ để giữ nguyên giao diện văn bản và giảm kích thước tệp."
---
## **Giới thiệu**

Embedding fonts stores font data inside a PowerPoint presentation. When a viewer supports embedded fonts, it can display text using those fonts even if they are not installed on the target system. This helps preserve line breaks, text spacing, and slide layout.

Aspose.Slides for Java cho phép bạn truy xuất, thêm và xóa các phông chữ được nhúng thông qua giao diện [IFontsManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsmanager/) được trả về bởi [Presentation.getFontsManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getFontsManager--). Bạn cũng có thể giảm kích thước dữ liệu phông chữ được nhúng bằng cách loại bỏ các ký tự mà bản trình bày không sử dụng.

Các ví dụ dưới đây hoạt động với tệp PPTX. Trước khi nhúng một phông chữ, hãy đảm bảo dữ liệu phông chữ của nó có sẵn cho Aspose.Slides và giấy phép của nó cho phép việc nhúng.

## **Lấy và Xóa Phông chữ Được Nhúng**

Sử dụng [getEmbeddedFonts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) để liệt kê các phông chữ được lưu trong một bản trình bày. Để xóa một phông chữ, truyền một phông chữ từ danh sách đó cho [removeEmbeddedFont](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-), sau đó lưu bản trình bày.

Ví dụ sau liệt kê các phông chữ được nhúng trong `EmbeddedFonts.pptx` và xóa Calibri nếu nó có mặt:

```java
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    for (IFontData font : embeddedFonts) {
        System.out.println(font.getFontName());
    }

    IFontData fontToRemove = null;
    for (IFontData font : embeddedFonts) {
        if ("Calibri".equalsIgnoreCase(font.getFontName())) {
            fontToRemove = font;
            break;
        }
    }

    if (fontToRemove != null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Việc xóa một phông chữ được nhúng sẽ xóa dữ liệu phông chữ đã lưu; nó không thay đổi phông chữ được gán cho văn bản. Nếu phông chữ đã được cài đặt trên hệ thống đích, văn bản vẫn có thể sử dụng nó. Ngược lại, quá trình render có thể yêu cầu [font substitution](/slides/vi/java/font-substitution/), điều này có thể ảnh hưởng đến bố cục.

## **Kiểm tra Dữ liệu Phông chữ và Quyền Nhúng**

Sử dụng giao diện [IFontsManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsmanager/) để kiểm tra các phông chữ trước khi nhúng chúng. Gọi [IFontsManager.getFonts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsmanager/#getFonts--) để lấy các phông chữ được sử dụng trong bản trình bày. Đối với mỗi phông chữ, truyền một đối tượng [IFontData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontdata/) và giá trị [FontStyleType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontstyletype/) cần thiết cho [IFontsManager.getFontBytes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-). Phương thức này trả về dữ liệu nhị phân cho kiểu phông chữ đó, hoặc `null` khi phông chữ hoặc kiểu yêu cầu không khả dụng. Đừng truyền kết quả `null` cho [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-), vì phương thức đó yêu cầu một mảng byte.

[EmbeddingLevel](https://reference.aspose.com/slides/vi/java/com.aspose.slides/embeddinglevel/) là một enumeration kiểu cờ báo cáo các hạn chế nhúng được lưu trong phông chữ:

- `Installable` cho phép nhúng và cài đặt vĩnh viễn trên hệ thống khác, tùy thuộc vào giấy phép của phông chữ.
- `Restricted` cấm nhúng trừ khi có được sự cho phép từ chủ sở hữu pháp lý của phông chữ khi đây là cờ quyền sử dụng duy nhất.
- `PreviewPrint` cho phép sử dụng tạm thời để xem và in; tài liệu chứa phông chữ phải ở chế độ chỉ đọc.
- `Editable` cho phép sử dụng tạm thời và cho phép tài liệu được chỉnh sửa và lưu.
- `NoSubsetting` là một hạn chế bổ sung ngăn việc nhúng chỉ một phần con của các glyph. Khi cờ này hiện hữu, phải nhúng tất cả các ký tự.
- `BitmapOnly` là một hạn chế bổ sung cho phép chỉ nhúng các bitmap strike, không nhúng dữ liệu outline. Nếu phông chữ không có bitmap strike, nó không thể được nhúng.

Bốn giá trị đầu mô tả quyền sử dụng, trong khi `NoSubsetting` và `BitmapOnly` có thể được kết hợp với chúng. Kiểm tra các bộ điều chỉnh bằng các phép toán bitwise. Vì `Installable` có giá trị zero, hãy tạo mask cho các bit quyền sử dụng và so sánh kết quả với `Installable` thay vì kiểm tra nó như một cờ. Các phông chữ hiện tại nên đặt tối đa một bit quyền sử dụng. Để tương thích với các phông chữ cũ đặt nhiều hơn một bit, trợ giúp dưới đây sẽ chọn quyền ít hạn chế nhất: `Editable`, sau đó `PreviewPrint`, sau đó `Restricted`.

Ví dụ dưới đây kiểm tra dữ liệu thường, đậm, nghiêng và đậm-nghiêng có sẵn cho mỗi phông chữ được `getFonts` trả về. Nó bỏ qua các kiểu không khả dụng, phông chữ bị hạn chế, phông chữ chỉ bitmap, các phông chữ giới hạn ở preview và print vì đầu ra vẫn có thể chỉnh sửa, và các phông chữ đã được nhúng. Nếu bất kỳ kiểu nào có sẵn có `NoSubsetting`, nó sẽ nhúng tất cả các ký tự cho họ phông chữ đó.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.EmbeddingLevel;
import com.aspose.slides.FontStyleType;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Locale;
import java.util.Set;

class EmbeddingPermission {
    int getUsagePermission(int level) {
        int permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
        int permissions = level & permissionMask;

        if ((permissions & EmbeddingLevel.Editable) != 0) {
            return EmbeddingLevel.Editable;
        }

        if ((permissions & EmbeddingLevel.PreviewPrint) != 0) {
            return EmbeddingLevel.PreviewPrint;
        }

        if ((permissions & EmbeddingLevel.Restricted) != 0) {
            return EmbeddingLevel.Restricted;
        }

        return EmbeddingLevel.Installable;
    }
}

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    int[] fontStyles = {
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic
    };

    Set<String> embeddedFontNames = new HashSet<String>();
    for (IFontData embeddedFont : fontsManager.getEmbeddedFonts()) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    EmbeddingPermission permissionHelper = new EmbeddingPermission();
    List<IFontData> fontsToEmbed = new ArrayList<IFontData>();
    List<Integer> embeddingRules = new ArrayList<Integer>();
    for (IFontData font : fontsManager.getFonts()) {
        if (embeddedFontNames.contains(font.getFontName().toLowerCase(Locale.ROOT))) {
            System.out.println(font.getFontName() + ": already embedded.");
            continue;
        }

        boolean hasAvailableData = false;
        boolean allAvailableStylesCanBeEmbedded = true;
        boolean previewPrintOnly = false;
        boolean requiresFullFont = false;

        for (int fontStyle : fontStyles) {
            byte[] fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes == null) {
                System.out.println(font.getFontName() + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            int embeddingLevel = fontsManager.getFontEmbeddingLevel(fontBytes, font.getFontName());
            int usagePermission = permissionHelper.getUsagePermission(embeddingLevel);
            boolean noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
            boolean bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

            requiresFullFont |= noSubsetting;
            previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

            System.out.println(font.getFontName() + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            System.out.println(font.getFontName() + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            System.out.println(font.getFontName() + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            System.out.println(font.getFontName() + ": skipped because this example produces an editable presentation.");
        } else {
            int rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.add(font);
            embeddingRules.add(rule);
        }
    }

    for (int i = 0; i < fontsToEmbed.size(); i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed.get(i), embeddingRules.get(i));
    }

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Việc kiểm tra này báo cáo các hạn chế được mã hoá trong mỗi tệp phông chữ. Nó không cấp giấy phép, không chứng minh rằng bạn đã có được phông chữ một cách hợp pháp, và không thay thế việc kiểm tra thỏa thuận giấy phép của phông chữ trước khi phân phối bản sao đã nhúng.

## **Thêm Phông chữ Được Nhúng**

Sử dụng [addEmbeddedFont](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) để nhúng một phông chữ. Các overload của nó chấp nhận hoặc một đối tượng [IFontData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontdata/) hoặc một mảng byte chứa dữ liệu phông chữ. Enumeration [EmbedFontCharacters](https://reference.aspose.com/slides/vi/java/com.aspose.slides/embedfontcharacters/) kiểm soát các ký tự nào sẽ được bao gồm:

- [All](https://reference.aspose.com/slides/vi/java/com.aspose.slides/embedfontcharacters/) nhúng tất cả các ký tự trong phông chữ. Sử dụng tùy chọn này khi người nhận cần chỉnh sửa bản trình bày và nhập văn bản mới.
- [OnlyUsed](https://reference.aspose.com/slides/vi/java/com.aspose.slides/embedfontcharacters/) chỉ nhúng các ký tự được sử dụng trong bản trình bày để giảm kích thước tệp. Chọn tùy chọn này cho một bản trình bày đã hoàn thiện, chủ yếu dành cho việc xem.

Ví dụ dưới đây sử dụng [getFonts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsmanager/#getFonts--) để lấy các phông chữ được sử dụng trong `Fonts.pptx` và nhúng những phông chữ chưa được nhúng. Các phông chữ cần thêm phải có sẵn trên máy chạy mã. Các phông chữ đã nhúng hiện có giữ lại bộ ký tự hiện tại của chúng.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.HashSet;
import java.util.Locale;
import java.util.Set;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] allFonts = fontsManager.getFonts();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();
    Set<String> embeddedFontNames = new HashSet<String>();

    for (IFontData embeddedFont : embeddedFonts) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    for (IFontData font : allFonts) {
        String fontName = font.getFontName().toLowerCase(Locale.ROOT);
        if (!embeddedFontNames.contains(fontName)) {
            fontsManager.addEmbeddedFont(font, EmbedFontCharacters.All);
            embeddedFontNames.add(fontName);
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nén Phông chữ Được Nhúng**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) giảm dữ liệu phông chữ được nhúng bằng cách loại bỏ các ký tự không dùng. Nó hoạt động trên các phông chữ đã được nhúng, do đó mức giảm kích thước phụ thuộc vào lượng dữ liệu phông chữ không dùng trong bản trình bày.

Ví dụ dưới đây nén các phông chữ trong `EmbeddedFonts.pptx` và lưu kết quả thành một tệp riêng:

```java
import com.aspose.slides.Compress;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Giữ lại tệp gốc nếu người nhận có thể cần thêm văn bản sau này. Các ký tự bị loại bỏ trong quá trình nén sẽ không còn khả dụng từ phông chữ đã nhúng, ngay cả khi bạn đã nhúng tất cả các ký tự ban đầu.

## **Câu hỏi thường gặp**

**Làm sao tôi có thể kiểm tra xem một phông chữ được nhúng có vẫn sẽ bị thay thế trong quá trình render không?**

Gọi [getSubstitutions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) trong môi trường bạn render bản trình bày để xem Aspose.Slides sẽ thay thế những phông chữ nào. Cũng kiểm tra cài đặt [font substitution](/slides/vi/java/font-substitution/) và quy tắc [font fallback](/slides/vi/java/fallback-font/). Fallback xử lý các ký tự thiếu, vì vậy việc nhúng phông chữ không giải quyết được các ký tự mà phông chữ đó không chứa.

**Tôi có nên nhúng các phông chữ phổ biến như Arial và Calibri không?**

Quyết định dựa trên môi trường mục tiêu. Nếu các phông chữ cần thiết có sẵn trên mọi máy mở hoặc render bản trình bày, việc nhúng chúng có thể làm tăng kích thước tệp không cần thiết. Nếu người nhận hoặc máy chủ có thể thiếu các phông chữ đó, việc nhúng chúng có thể giúp bảo toàn giao diện mong muốn, với điều kiện giấy phép của chúng cho phép.