---
title: 在 Android 上寫入保護簡報
linktitle: 寫入保護
type: docs
weight: 25
url: /zh-hant/androidjava/write-protected-presentation/
keywords:
- 寫入保護
- 寫入保護 PowerPoint
- 修改密碼
- 限制簡報編輯
- 移除寫入保護
- 驗證修改密碼
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 在 PowerPoint PPT 與 PPTX 簡報中設定、偵測、驗證與移除寫入保護密碼。"
---
## **簡介**

寫入保護密碼會限制簡報的修改，但不會加密其內容。使用者可以在不輸入密碼的情況下載入並檢視寫入保護的簡報。視應用程式而定，他們甚至可能編輯內容並另存為不同的檔名，因此寫入保護不應被視為機密性機制。

開啟密碼則有不同的目的：它會加密簡報，且載入內容時必須提供。若要加密簡報或驗證開啟密碼，請參閱[Password-Protect Presentations](/slides/zh-hant/androidjava/password-protected-presentation/)。

本文中的工作流程同時適用於 PPT 和 PPTX 簡報。範例使用 PPTX 檔案；若保存為 PPT，請使用`.ppt`副檔名及相應的 PPT 保存格式。

## **在簡報上設定寫入保護**

使用[IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-)為簡報指定修改密碼。保存簡報時會保留此保護設定。

以下例子在 PPTX 簡報上設定寫入保護：

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

因為寫入保護不會加密簡報內容，載入簡報時不需要密碼。密碼僅在驗證是否有權限修改受保護的簡報時才相關。

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

不要將寫入保護密碼傳遞給[ILoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-)。此方法接受的是加密內容的開啟密碼。如果簡報同時具備兩種保護類型，請在載入時提供開啟密碼，並另行處理寫入保護密碼。

## **從簡報中移除寫入保護**

使用[IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iprotectionmanager/#removeWriteProtection--)移除修改限制，然後保存簡報。

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

## **檢查簡報是否受寫入保護**

若要在不建立完整[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/)實例的情況下檢查檔案，呼叫[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-)並檢查[IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--)。此方法使用[NullableBool](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/nullablebool/)並在偵測到寫入保護時返回`NullableBool.True`。

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

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-)的串流重載提供相同的資訊，適用於以串流方式提供的簡報。

## **驗證寫入保護密碼**

使用[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-)在不載入完整簡報的情況下驗證修改密碼。先檢查[IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--)，以便在只有寫入保護存在時才要求或驗證密碼。

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

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-)僅驗證寫入保護密碼。它不會驗證開啟密碼，也不會判斷是否能載入加密內容。相反地，[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-)僅驗證開啟密碼。如果已經載入完整簡報，則[IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-)可透過其保護管理員提供等效的寫入保護檢查。

在正式應用程式中，請勿記錄密碼或將其包含在診斷訊息中。避免不必要的重複驗證嘗試，且僅在需要時才在記憶體中保留密碼。

{{% alert color="info" title="另請參閱" %}}
- [Password-Protect Presentations](/slides/zh-hant/androidjava/password-protected-presentation/)
- [Read-Only Presentations](/slides/zh-hant/androidjava/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/zh-hant/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**寫入保護會加密簡報嗎？**

不會。它僅限制修改，且簡報內容仍可載入和檢視。

**開啟簡報是否需要寫入保護密碼？**

不需要。僅需開啟密碼才能載入加密的簡報內容。

**簡報能同時擁有開啟密碼與寫入保護密碼嗎？**

可以。請透過載入選項提供開啟密碼以開啟加密的簡報，並在需要修改授權時另行驗證寫入保護密碼。