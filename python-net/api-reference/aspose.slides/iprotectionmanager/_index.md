---
title: IProtectionManager Class
type: docs
weight: 2290
url: /python-net/api-reference/aspose.slides/iprotectionmanager/
---

Presentation password protestion management.

**Namespace:** [aspose.slides](/slides/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.IProtectionManager



The IProtectionManager type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|encrypt_document_properties|This property makes sense, if presentation is password protected.<br/>            If true then document properties is encrypted in presentation file.<br/>            If false then document properties is public while presentation is encrypted.<br/>            Read/write bool.|
|is_encrypted|Gets a value indicating whether this instance is encrypted.<br/>            Read-only bool.|
|is_only_document_properties_loaded|This property makes sense, if presentation file is password protected and document <br/>            properties of this file are public.<br/>            Value of true means that only document properties are loaded from an encrypted <br/>            presentation file without use of password.<br/>            Value of false means that entire encrypted presentation is loaded with use of right <br/>            password, not only document properties are loaded.<br/>            If presentation isn't encrypted then property value is always false.<br/>            If document properties of an encrypted file aren't public then property value is always false.<br/>            If PresentationEx.EncryptDocumentProperties is true than IsOnlyDocumentPropertiesLoaded <br/>            property value is always false.<br/>            Read-only bool.|
|is_write_protected|Gets a value indicating whether this presentation is write protected.<br/>            Read-only bool.|
|encryption_password|Returns encryption password.<br/>            Read-only string.|
|read_only_recommended|Gets or sets read-only recommendation.<br/>            Read/write bool.|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|encrypt(encryption_password)|Encrypts Presentation with specified password.|
|remove_encryption()|Removes the encryption.|
|set_write_protection(password)|Set write protection for this presentation with specified password.|
|remove_write_protection()|Removes write protection for this presentation.|
|check_write_protection(password)|Determines whether a presentation is a password protected to modify.|
