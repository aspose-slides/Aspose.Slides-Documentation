---
title: 在 Java 中寫入保護簡報
linktitle: 寫入保護
type: docs
weight: 25
url: /zh-hant/java/write-protected-presentation/
keywords:
- 寫入保護
- 寫入保護 PowerPoint
- 修改密碼
- 限制簡報編輯
- 移除寫入保護
- 驗證修改密碼
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint PPT 和 PPTX 簡報中設定、偵測、驗證及移除寫入保護密碼。"
---
## **簡介**

寫入保護密碼限制對簡報的修改，但不會加密其內容。使用者可以在未輸入密碼的情況下載入並檢視寫入保護的簡報。視應用程式而定，使用者也可能編輯內容並以不同名稱儲存，因此寫入保護不應被視為保密機制。

開啟密碼的目的不同：它會加密簡報，且載入內容時需要提供此密碼。若要加密簡報或驗證開啟密碼，請參閱[Password-Protect Presentations](/slides/zh-hant/java/password-protected-presentation/)。

本文件中的工作流程同時適用於 PPT 和 PPTX 簡報。範例使用 PPTX 檔案；若儲存為 PPT，請使用 `.ppt` 副檔名以及相對應的 PPT 儲存格式。

## **在簡報上設定寫入保護**

使用[IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-)為簡報指定修改密碼。儲存簡報時會保留這項保護設定。

以下範例在 PPTX 簡報上設定寫入保護：

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **載入寫入保護的簡報**

由於寫入保護不會加密簡報內容，載入簡報時不需要密碼。此密碼僅在驗證修改受保護簡報的授權時才相關。

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

不要將寫入保護密碼傳遞給[ILoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-)。此方法接受用於加密內容的開啟密碼。如果簡報同時具有兩種保護，請提供開啟密碼以載入簡報，並另行處理寫入保護密碼。

## **從簡報中移除寫入保護**

使用[IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iprotectionmanager/#removeWriteProtection--)移除修改限制，然後儲存簡報。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **檢查簡報是否具有寫入保護**

若要在不建立完整[Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/)實例的情況下檢查檔案，呼叫[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-)並檢查[IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--)。此方法使用[NullableBool](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/nullablebool/)並在偵測到寫入保護時返回`NullableBool.True`。

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() == NullableBool.True) {
    System.out.println("The presentation is write protected.");
} else {
    System.out.println("Write protection was not detected.");
}
```

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-)的串流重載可為以串流提供的簡報提供相同資訊。

## **驗證寫入保護密碼**

使用[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-)在未載入完整簡報的情況下驗證修改密碼。先檢查[IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--)，以確保應用程式僅在存在寫入保護時才請求或驗證密碼。

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-)僅驗證寫入保護密碼。它不會驗證開啟密碼，也不會判斷是否能載入加密內容。相對地，[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-)僅驗證開啟密碼。如果已載入完整簡報，則[IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-)可透過其保護管理器提供等效的寫入保護檢查。

在正式應用程式中，請勿記錄密碼或在診斷訊息中包含密碼。避免不必要的重複驗證，並僅在需要時於記憶體中保留密碼。

{{% alert color="info" title="另請參閱" %}}
- [密碼保護簡報](/slides/zh-hant/java/password-protected-presentation/)
- [唯讀簡報](/slides/zh-hant/java/read-only-presentation/)
- [PowerPoint 中的數位簽章](/slides/zh-hant/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**寫入保護會加密簡報嗎？**

不會。它限制修改，但仍允許載入和檢視簡報內容。

**開啟簡報是否需要寫入保護密碼？**

不需要。僅需開啟密碼即可載入加密的簡報內容。

**簡報可以同時具有開啟密碼和寫入保護密碼嗎？**

可以。透過載入選項提供開啟密碼以開啟加密的簡報，並在需要修改授權時分別驗證寫入保護密碼。